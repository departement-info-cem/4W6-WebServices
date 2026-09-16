using Microsoft.AspNetCore.Mvc;
using TP2_serveur.Data;
using TP2_serveur.DTOs.Spotify;
using TP2_serveur.Models;
using TP2_serveur.Spotify;

namespace TP2_serveur.Controllers.Spotify
{
    /// <summary>
    /// Albums : l'équivalent maison de https://api.spotify.com/v1/albums
    ///
    /// GET http://localhost:5143/v1/albums/ID_ALBUM
    /// GET http://localhost:5143/v1/albums/ID_ALBUM/tracks
    ///   Authorization : Bearer VOTRE_TOKEN
    ///
    /// Les chansons de l'album se trouvent dans tracks.items !
    /// </summary>
    [Route("v1/albums")]
    [ApiController]
    [SpotifyAuthorize]
    public class SpotifyAlbumsController : ControllerBase
    {
        private readonly TP2_serveurContext _context;

        public SpotifyAlbumsController(TP2_serveurContext context)
        {
            _context = context;
        }

        /// <summary>GET /v1/albums/{id}</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetAlbum(string id)
        {
            if (!SpotifyId.IsWellFormed(id)) return SpotifyErrors.InvalidBase62Id();

            Album? album = await FindAlbum(id);
            if (album == null) return SpotifyErrors.NonExistingId();

            return Ok(new SpotifyMapper(Request).ToAlbumObject(album));
        }

        /// <summary>GET /v1/albums?ids=id1,id2,...</summary>
        [HttpGet]
        public async Task<ActionResult> GetAlbums([FromQuery(Name = "ids")] string? ids)
        {
            if (string.IsNullOrWhiteSpace(ids))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "No ids provided");
            }

            string[] requested = ids.Split(',', StringSplitOptions.TrimEntries);

            if (requested.Length > 20)
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Too many ids requested");
            }

            SpotifyMapper mapper = new SpotifyMapper(Request);
            List<AlbumObject?> albums = [];

            foreach (string requestedId in requested)
            {
                if (!SpotifyId.IsWellFormed(requestedId)) return SpotifyErrors.InvalidBase62Id();

                Album? album = await FindAlbum(requestedId);
                albums.Add(album == null ? null : mapper.ToAlbumObject(album));
            }

            return Ok(new AlbumsResponse { Albums = albums });
        }

        /// <summary>GET /v1/albums/{id}/tracks</summary>
        [HttpGet("{id}/tracks")]
        public async Task<ActionResult> GetTracks(
            string id,
            [FromQuery(Name = "limit")] string? limit,
            [FromQuery(Name = "offset")] string? offset)
        {
            if (!SpotifyId.IsWellFormed(id)) return SpotifyErrors.InvalidBase62Id();

            if (!SpotifyPaging.TryParseLimit(limit, 20, out int pageSize))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Invalid limit");
            }

            if (!SpotifyPaging.TryParseOffset(offset, out int start))
            {
                return SpotifyErrors.Api(StatusCodes.Status400BadRequest, "Invalid offset");
            }

            Album? album = await FindAlbum(id);
            if (album == null) return SpotifyErrors.NonExistingId();

            List<Song> songs = [.. album.Songs.OrderBy(s => s.Id)];
            SpotifyMapper mapper = new SpotifyMapper(Request);
            string baseUrl = $"{Request.Scheme}://{Request.Host}";

            return Ok(SpotifyPaging.Create(
                songs.Skip(start).Take(pageSize).Select((song, index) => mapper.ToSimplifiedTrackObject(song, start + index + 1)),
                pageSize,
                start,
                songs.Count,
                (pageOffset, pageLimit) => $"{baseUrl}/v1/albums/{id}/tracks?offset={pageOffset}&limit={pageLimit}"));
        }

        private async Task<Album?> FindAlbum(string spotifyId)
        {
            return SpotifyId.TryDecode(spotifyId, SpotifyIdType.Album, out int albumId)
                ? await _context.Album.FindAsync(albumId)
                : null;
        }
    }
}
