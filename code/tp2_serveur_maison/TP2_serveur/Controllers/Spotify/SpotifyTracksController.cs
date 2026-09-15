using Microsoft.AspNetCore.Mvc;
using TP2_serveur.Data;
using TP2_serveur.Models;
using TP2_serveur.Spotify;

namespace TP2_serveur.Controllers.Spotify
{
    /// <summary>
    /// Chansons : l'équivalent maison de https://api.spotify.com/v1/tracks
    ///
    /// GET http://localhost:5143/v1/tracks/ID_CHANSON
    ///   Authorization : Bearer VOTRE_TOKEN
    /// </summary>
    [Route("v1/tracks")]
    [ApiController]
    [SpotifyAuthorize]
    public class SpotifyTracksController : ControllerBase
    {
        private readonly TP2_serveurContext _context;

        public SpotifyTracksController(TP2_serveurContext context)
        {
            _context = context;
        }

        /// <summary>GET /v1/tracks/{id}</summary>
        [HttpGet("{id}")]
        public async Task<ActionResult> GetTrack(string id)
        {
            if (!SpotifyId.IsWellFormed(id)) return SpotifyErrors.InvalidBase62Id();

            Song? song = await FindSong(id);
            if (song == null) return SpotifyErrors.NonExistingId();

            return Ok(new SpotifyMapper(Request).ToTrackObject(song));
        }

        /// <summary>GET /v1/tracks?ids=id1,id2,...</summary>
        [HttpGet]
        public async Task<ActionResult> GetTracks([FromQuery(Name = "ids")] string? ids)
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
            List<object?> tracks = [];

            foreach (string requestedId in requested)
            {
                if (!SpotifyId.IsWellFormed(requestedId)) return SpotifyErrors.InvalidBase62Id();

                Song? song = await FindSong(requestedId);
                tracks.Add(song == null ? null : mapper.ToTrackObject(song));
            }

            return Ok(new { tracks });
        }

        private async Task<Song?> FindSong(string spotifyId)
        {
            return SpotifyId.TryDecode(spotifyId, SpotifyIdType.Track, out int songId)
                ? await _context.Song.FindAsync(songId)
                : null;
        }
    }
}
