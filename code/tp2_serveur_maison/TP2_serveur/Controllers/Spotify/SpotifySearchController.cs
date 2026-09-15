using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP2_serveur.Data;
using TP2_serveur.DTOs.Spotify;
using TP2_serveur.Models;
using TP2_serveur.Spotify;

namespace TP2_serveur.Controllers.Spotify
{
    /// <summary>
    /// Recherche : l'équivalent maison de https://api.spotify.com/v1/search
    ///
    /// GET http://localhost:5143/v1/search?type=artist&amp;offset=0&amp;limit=1&amp;q=NOM_ARTISTE
    ///   Authorization : Bearer VOTRE_TOKEN
    /// </summary>
    [Route("v1/search")]
    [ApiController]
    [SpotifyAuthorize]
    public class SpotifySearchController : ControllerBase
    {
        private readonly TP2_serveurContext _context;

        public SpotifySearchController(TP2_serveurContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Search(
            [FromQuery(Name = "q")] string? q,
            [FromQuery(Name = "type")] string? type,
            [FromQuery(Name = "limit")] string? limit,
            [FromQuery(Name = "offset")] string? offset)
        {
            if (string.IsNullOrWhiteSpace(q))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "No search query");
            }

            string[] types = (type ?? "")
                .Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .Select(t => t.ToLowerInvariant())
                .ToArray();

            if (types.Length == 0)
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Missing parameter type");
            }

            foreach (string searchType in types)
            {
                if (!SpotifySearch.ValidTypes.Contains(searchType))
                {
                    return SpotifyErrors.Api(StatusCodes.Status400BadRequest, $"Bad search type field {searchType}");
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

            SpotifyMapper mapper = new SpotifyMapper(Request);

            return Ok(new SearchResponse
            {
                Artists = types.Contains("artist") ? await SearchArtists(mapper, q, pageSize, start) : null,
                Albums = types.Contains("album") ? await SearchAlbums(mapper, q, pageSize, start) : null,
                Tracks = types.Contains("track") ? await SearchTracks(mapper, q, pageSize, start) : null
            });
        }

        private async Task<PagingObject<ArtistObject>> SearchArtists(SpotifyMapper mapper, string query, int limit, int offset)
        {
            // La base de données du serveur maison est minuscule : on peut trier les
            // résultats en mémoire sans que ce soit un problème.
            List<Artist> found = [.. (await _context.Artist.ToListAsync())
                .Where(a => SpotifySearch.Matches(a.Name, query))
                .OrderBy(a => SpotifySearch.Rank(a.Name, query))
                .ThenBy(a => a.Name)];

            return Page(found.Skip(offset).Take(limit).Select(mapper.ToArtistObject), query, "artist", limit, offset, found.Count);
        }

        private async Task<PagingObject<SimplifiedAlbumObject>> SearchAlbums(SpotifyMapper mapper, string query, int limit, int offset)
        {
            List<Album> found = [.. (await _context.Album.ToListAsync())
                .Where(a => SpotifySearch.Matches(a.Name, query))
                .OrderBy(a => SpotifySearch.Rank(a.Name, query))
                .ThenBy(a => a.Name)];

            return Page(found.Skip(offset).Take(limit).Select(a => mapper.ToSimplifiedAlbumObject(a)), query, "album", limit, offset, found.Count);
        }

        private async Task<PagingObject<TrackObject>> SearchTracks(SpotifyMapper mapper, string query, int limit, int offset)
        {
            List<Song> found = [.. (await _context.Song.ToListAsync())
                .Where(s => SpotifySearch.Matches(s.Name, query))
                .OrderBy(s => SpotifySearch.Rank(s.Name, query))
                .ThenBy(s => s.Name)];

            return Page(found.Skip(offset).Take(limit).Select(mapper.ToTrackObject), query, "track", limit, offset, found.Count);
        }

        private PagingObject<T> Page<T>(IEnumerable<T> items, string query, string type, int limit, int offset, int total)
        {
            string baseUrl = $"{Request.Scheme}://{Request.Host}";

            return SpotifyPaging.Create(items, limit, offset, total, (pageOffset, pageLimit) =>
                $"{baseUrl}/v1/search?offset={pageOffset}&limit={pageLimit}&query={Uri.EscapeDataString(query)}&type={type}");
        }
    }
}
