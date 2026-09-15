using System.Text.Json.Serialization;

namespace TP2_serveur.DTOs.Spotify
{
    /// <summary>
    /// Réponse de POST /api/token, identique à celle de https://accounts.spotify.com/api/token.
    /// C'est dans <c>access_token</c> que se trouve le fameux token !
    /// </summary>
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; init; } = null!;

        [JsonPropertyName("token_type")]
        public string TokenType { get; init; } = "Bearer";

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; init; }
    }

    /// <summary>
    /// Erreur de POST /api/token. Attention : ce format (OAuth 2.0) n'est pas le même
    /// que celui des erreurs du reste de l'API !
    /// </summary>
    public class TokenErrorResponse
    {
        [JsonPropertyName("error")]
        public string Error { get; init; } = null!;

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; init; } = null!;
    }

    /// <summary>Erreur de n'importe quelle requête /v1/... : { "error": { "status": ..., "message": ... } }</summary>
    public class ApiErrorResponse
    {
        [JsonPropertyName("error")]
        public ApiErrorDetails Error { get; init; } = null!;
    }

    public class ApiErrorDetails
    {
        [JsonPropertyName("status")]
        public int Status { get; init; }

        [JsonPropertyName("message")]
        public string Message { get; init; } = null!;
    }
}
