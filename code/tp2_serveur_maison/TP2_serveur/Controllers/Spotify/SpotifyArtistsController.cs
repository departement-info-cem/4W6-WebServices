using Microsoft.AspNetCore.Mvc;
using TP2_serveur.Data;
using TP2_serveur.DTOs.Spotify;
using TP2_serveur.Models;
using TP2_serveur.Spotify;

namespace TP2_serveur.Controllers.Spotify
{
    /// <summary>
    /// Artistes : l'équivalent maison de https://api.spotify.com/v1/artists
    ///
    /// GET http://localhost:5143/v1/artists/ID_ARTISTE
    /// GET http://localhost:5143/v1/artists/ID_ARTISTE/albums?include_groups=album,single
    ///   Authorization : Bearer VOTRE_TOKEN
    /// </summary>
    [Route("v1/artists")]
    [ApiController]
    [SpotifyAuthorize]
    public class SpotifyArtistsController : ControllerBase
    {
        /// <summary>Les catégories d'albums acceptées par le paramètre include_groups.</summary>
        private static readonly string[] ValidGroups = ["album", "single", "appears_on", "compilation"];

        private readonly TP2_serveurContext _context;

        public SpotifyArtistsController(TP2_serveurContext context)
        {
            _context = context;
        }

        /// <summary>GET /v1/artists/{id}</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetArtist(string id)
        {
            if (!SpotifyId.IsWellFormed(id)) return SpotifyErrors.InvalidBase62Id();

            Artist? artist = await FindArtist(id);
            if (artist == null) return SpotifyErrors.NonExistingId();

            return Ok(new SpotifyMapper(Request).ToArtistObject(artist));
        }

        /// <summary>GET /v1/artists?ids=id1,id2,...</summary>
        [HttpGet]
        public async Task<ActionResult> GetArtists([FromQuery(Name = "ids")] string? ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "No ids provided");
            }

            string[] requested = ids.Split(',', StringSplitOptions.TrimEntries);

            if (requested.Length > 50)
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Too many ids requested");
            }

            SpotifyMapper mapper = new SpotifyMapper(Request);
            List<ArtistObject?> artists = [];

            foreach (string requestedId in requested)
            {
                if (!SpotifyId.IsWellFormed(requestedId)) return SpotifyErrors.InvalidBase62Id();

                Artist? artist = await FindArtist(requestedId);

                // Spotify range simplement « null » à la place des artistes introuvables
                artists.Add(artist == null ? null : mapper.ToArtistObject(artist));
            }

            return Ok(new ArtistsResponse { Artists = artists });
        }

        /// <summary>GET /v1/artists/{id}/albums</summary>
        [HttpGet("{id}/albums")]
        public async Task<ActionResult> GetAlbums(
            string id,
            [FromQuery(Name = "include_groups")] string? includeGroups,
            [FromQuery(Name = "limit")] string? limit,
            [FromQuery(Name = "offset")] string? offset)
        {
            if (!SpotifyId.IsWellFormed(id)) return SpotifyErrors.InvalidBase62Id();

            string[] groups = (includeGroups ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(g => g.ToLowerInvariant())
                .ToArray();

            foreach (string group in groups)
            {
                if (!ValidGroups.Contains(group))
                {
                    return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Invalid include_groups");
                }
            }

            if (!SpotifyPaging.TryParseLimit(limit, 20, out int pageSize))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Invalid limit");
            }

            if (!SpotifyPaging.TryParseOffset(offset, out int start))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Invalid offset");
            }

            Artist? artist = await FindArtist(id);
            if (artist == null) return SpotifyErrors.NonExistingId();

            // Tous les albums du serveur maison sont de type « album » : si on demande
            // uniquement des singles ou des compilations, il n'y a donc aucun résultat.
            List<Album> albums = groups.Length == 0 || groups.Contains("album")
                ? [.. artist.Albums.OrderBy(a => a.Id)]
                : [];

            SpotifyMapper mapper = new SpotifyMapper(Request);
            string baseUrl = $"{Request.Scheme}://{Request.Host}";
            string groupsQuery = groups.Length == 0 ? "" : $"&include_groups={string.Join(",", groups)}";

            return Ok(SpotifyPaging.Create(
                albums.Skip(start).Take(pageSize).Select(a => mapper.ToSimplifiedAlbumObject(a, "album")),
                pageSize,
                start,
                albums.Count,
                (pageOffset, pageLimit) => $"{baseUrl}/v1/artists/{id}/albums?offset={pageOffset}&limit={pageLimit}{groupsQuery}"));
        }

        private async Task<Artist?> FindArtist(string spotifyId)
        {
            return SpotifyId.TryDecode(spotifyId, SpotifyIdType.Artist, out int artistId)
                ? await _context.Artist.FindAsync(artistId)
                : null;
        }
    }
}
