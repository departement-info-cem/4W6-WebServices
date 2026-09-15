using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Vérifie le token d'authentification d'une requête à /v1/... en imitant les
    /// messages d'erreur de Spotify :
    ///
    /// • Aucun en-tête Authorization       → 401 « No token provided »
    /// • En-tête qui n'est pas « Bearer »  → 400 « Only valid bearer authentication supported »
    /// • Token illisible ou mal signé      → 401 « Invalid access token »
    /// • Token expiré                      → 401 « The access token expired »
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SpotifyAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private const string Scheme = "Bearer";

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string? header = context.HttpContext.Request.Headers.Authorization.FirstOrDefault();

            // Aucun en-tête Authorization n'a été joint à la requête
            if (string.IsNullOrWhiteSpace(header))
            {
                context.Result = SpotifyErrors.Api(StatusCodes.Status401Unauthorized, "No token provided");
                return;
            }

            // L'en-tête existe, mais ce n'est pas un token « Bearer » (par exemple « Basic ... »)
            if (!header.StartsWith(Scheme, StringComparison.OrdinalIgnoreCase)
                || (header.Length > Scheme.Length && header[Scheme.Length] != ' '))
            {
                context.Result = SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Only valid bearer authentication supported");
                return;
            }

            string token = header[Scheme.Length..].Trim();

            try
            {
                new JwtSecurityTokenHandler().ValidateToken(token, ValidationParameters, out _);
            }
            catch (SecurityTokenExpiredException)
            {
                Reject(context, "The access token expired");
                return;
            }
            catch (Exception)
            {
                Reject(context, "Invalid access token");
                return;
            }
        }

        /// <summary>Paramètres servant à valider la signature et la validité d'un token.</summary>
        public static TokenValidationParameters ValidationParameters => new()
        {
            ValidateIssuer = true,
            ValidIssuer = SpotifyCredentials.Issuer,
            ValidateAudience = true,
            ValidAudience = SpotifyCredentials.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(SpotifyCredentials.SigningKey)),
            ValidateLifetime = true,
            ClockSkew = TimeSpan.Zero // Le token expire à la seconde près, comme chez Spotify
        };

        private static void Reject(AuthorizationFilterContext context, string message)
        {
            // Spotify joint cet en-tête à ses réponses 401 : autant faire pareil !
            context.HttpContext.Response.Headers.WWWAuthenticate =
                $"Bearer realm=\"spotify\", error=\"invalid_token\", error_description=\"{message}\"";

            context.Result = SpotifyErrors.Api(StatusCodes.Status401Unauthorized, message);
        }
    }
}
