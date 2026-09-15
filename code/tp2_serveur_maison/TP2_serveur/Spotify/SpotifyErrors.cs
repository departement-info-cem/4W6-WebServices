using Microsoft.AspNetCore.Mvc;
using TP2_serveur.DTOs.Spotify;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Fabrique les réponses d'erreur exactement comme le fait Spotify.
    ///
    /// ⚠ Spotify utilise DEUX formats d'erreur différents :
    /// • POST /api/token  →  { "error": "invalid_client", "error_description": "Invalid client" }
    /// • GET  /v1/...     →  { "error": { "status": 401, "message": "Invalid access token" } }
    /// </summary>
    public static class SpotifyErrors
    {
        /// <summary>Erreur d'une requête à /v1/...</summary>
        public static ObjectResult Api(int status, string message)
        {
            return new ObjectResult(new ApiErrorResponse
            {
                Error = new ApiErrorDetails { Status = status, Message = message }
            })
            {
                StatusCode = status
            };
        }

        /// <summary>Erreur d'une requête de connexion à /api/token.</summary>
        public static ObjectResult Token(string error, string description)
        {
            return new ObjectResult(new TokenErrorResponse
            {
                Error = error,
                ErrorDescription = description
            })
            {
                StatusCode = StatusCodes.Status400BadRequest
            };
        }

        /// <summary>L'identifiant reçu n'a pas la forme d'un id Spotify. (22 caractères en base 62)</summary>
        public static ObjectResult InvalidBase62Id() => Api(StatusCodes.Status400BadRequest, "Invalid base62 id");

        /// <summary>L'identifiant est bien formé, mais aucun objet ne lui correspond.</summary>
        public static ObjectResult NonExistingId() => Api(StatusCodes.Status404NotFound, "Non existing id");
    }
}
