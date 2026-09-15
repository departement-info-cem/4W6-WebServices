using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TP2_serveur.DTOs.Spotify;
using TP2_serveur.Spotify;

namespace TP2_serveur.Controllers.Spotify
{
    /// <summary>
    /// Requête de connexion : l'équivalent maison de https://accounts.spotify.com/api/token
    ///
    /// POST http://localhost:5143/api/token
    ///   Content-Type  : application/x-www-form-urlencoded
    ///   Authorization : Basic base64(CLIENT_ID:CLIENT_SECRET)
    ///   Corps         : grant_type=client_credentials
    /// </summary>
    [Route("api/token")]
    [ApiController]
    public class SpotifyTokenController : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> Token()
        {
            // Le corps de la requête est un formulaire. (application/x-www-form-urlencoded)
            IFormCollection form = Request.HasFormContentType ? await Request.ReadFormAsync() : new FormCollection(null);

            // Étape 1 : identifier l'application cliente, soit avec l'en-tête « Basic »,
            // soit avec les champs client_id et client_secret du formulaire.
            if (!TryReadCredentials(form, out string? clientId, out string? clientSecret))
            {
                return SpotifyErrors.Token("invalid_client", "Invalid client");
            }

            if (clientId != SpotifyCredentials.ClientId)
            {
                return SpotifyErrors.Token("invalid_client", "Invalid client");
            }

            if (clientSecret != SpotifyCredentials.ClientSecret)
            {
                return SpotifyErrors.Token("invalid_client", "Invalid client secret");
            }

            // Étape 2 : vérifier le type de connexion demandé
            string? grantType = form["grant_type"].FirstOrDefault();

            if (string.IsNullOrEmpty(grantType))
            {
                return SpotifyErrors.Token("unsupported_grant_type", "grant_type parameter is missing");
            }

            if (grantType != "client_credentials")
            {
                return SpotifyErrors.Token("unsupported_grant_type", "grant_type must be client_credentials, authorization_code or refresh_token");
            }

            // Étape 3 : fabriquer le token !
            return Ok(new TokenResponse
            {
                AccessToken = CreateAccessToken(clientId),
                TokenType = "Bearer",
                ExpiresIn = SpotifyCredentials.TokenLifetimeSeconds
            });
        }

        /// <summary>
        /// Récupère le CLIENT_ID et le CLIENT_SECRET. Spotify accepte les deux façons de
        /// les fournir : dans l'en-tête Authorization ou dans le corps de la requête.
        /// </summary>
        private bool TryReadCredentials(IFormCollection form, out string? clientId, out string? clientSecret)
        {
            clientId = null;
            clientSecret = null;

            string? header = Request.Headers.Authorization.FirstOrDefault();

            if (!string.IsNullOrWhiteSpace(header))
            {
                if (!header.StartsWith("Basic ", StringComparison.OrdinalIgnoreCase)) return false;

                string decoded;
                try
                {
                    // « Basic » signifie que CLIENT_ID:CLIENT_SECRET a été encodé en base 64
                    decoded = Encoding.UTF8.GetString(Convert.FromBase64String(header["Basic ".Length..].Trim()));
                }
                catch (FormatException)
                {
                    return false;
                }

                int separator = decoded.IndexOf(':');
                if (separator < 0) return false;

                clientId = decoded[..separator];
                clientSecret = decoded[(separator + 1)..];

                return true;
            }

            clientId = form["client_id"].FirstOrDefault();
            clientSecret = form["client_secret"].FirstOrDefault();

            return clientId != null && clientSecret != null;
        }

        /// <summary>Génère et chiffre le token qu'il faudra joindre aux prochaines requêtes.</summary>
        private static string CreateAccessToken(string clientId)
        {
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SpotifyCredentials.SigningKey));

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: SpotifyCredentials.Issuer,
                audience: SpotifyCredentials.Audience,
                claims: [new Claim("client_id", clientId)],
                expires: DateTime.UtcNow.AddSeconds(SpotifyCredentials.TokenLifetimeSeconds),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
