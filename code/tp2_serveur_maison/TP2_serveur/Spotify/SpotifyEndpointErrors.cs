using System.Text.Json;
using TP2_serveur.DTOs.Spotify;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Traduit en erreurs « à la Spotify » les réponses que ASP.NET produit lui-même,
    /// c'est-à-dire lorsqu'aucune route ne correspond à la requête reçue.
    /// </summary>
    public static class SpotifyEndpointErrors
    {
        public static IApplicationBuilder UseSpotifyEndpointErrors(this IApplicationBuilder app)
        {
            return app.Use(async (context, next) =>
            {
                await next();

                // Une réponse a déjà été préparée par un contrôleur : on n'y touche pas
                if (context.Response.HasStarted || context.Response.ContentType != null) return;

                if (!IsSpotifyPath(context.Request.Path)) return;

                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                {
                    await WriteError(context, StatusCodes.Status404NotFound, "Service not found");
                }
                else if (context.Response.StatusCode == StatusCodes.Status405MethodNotAllowed)
                {
                    await WriteError(context, StatusCodes.Status405MethodNotAllowed,
                        "Method Not Allowed. Please see https://developer.spotify.com/documentation/web-api");
                }
            });
        }

        private static bool IsSpotifyPath(PathString path)
        {
            return path.StartsWithSegments("/v1") || path.StartsWithSegments("/api/token");
        }

        private static async Task WriteError(HttpContext context, int status, string message)
        {
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json";

            await context.Response.WriteAsync(JsonSerializer.Serialize(new ApiErrorResponse
            {
                Error = new ApiErrorDetails { Status = status, Message = message }
            }));
        }
    }
}
