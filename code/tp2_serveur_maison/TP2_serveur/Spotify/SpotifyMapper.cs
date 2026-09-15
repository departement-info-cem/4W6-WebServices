using TP2_serveur.DTOs.Spotify;
using TP2_serveur.Models;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Transforme les artistes, albums et chansons de la base de données en objets JSON
    /// ayant exactement la même forme que ceux de l'API Web de Spotify.
    /// </summary>
    public class SpotifyMapper
    {
        /// <summary>Adresse du serveur maison, par exemple http://localhost:5143</summary>
        private readonly string _baseUrl;

        public SpotifyMapper(HttpRequest request)
        {
            _baseUrl = $"{request.Scheme}://{request.Host}";
        }

        #region Artistes

        public ArtistObject ToArtistObject(Artist artist)
        {
            string id = SpotifyId.Encode(SpotifyIdType.Artist, artist.Id);

            return new ArtistObject
            {
                ExternalUrls = ExternalUrls("artist", id),
                Followers = new FollowersObject { Href = null, Total = SpotifyMetadata.Followers(artist.Id) },
                Genres = [],
                Href = $"{_baseUrl}/v1/artists/{id}",
                Id = id,
                Images = Images(artist.ImageUrl, 640, 320, 160),
                Name = artist.Name,
                Popularity = SpotifyMetadata.Popularity(SpotifyIdType.Artist, artist.Id),
                Uri = $"spotify:artist:{id}"
            };
        }

        public SimplifiedArtistObject ToSimplifiedArtistObject(Artist artist)
        {
            string id = SpotifyId.Encode(SpotifyIdType.Artist, artist.Id);

            return new SimplifiedArtistObject
            {
                ExternalUrls = ExternalUrls("artist", id),
                Href = $"{_baseUrl}/v1/artists/{id}",
                Id = id,
                Name = artist.Name,
                Uri = $"spotify:artist:{id}"
            };
        }

        #endregion

        #region Albums

        public SimplifiedAlbumObject ToSimplifiedAlbumObject(Album album, string? albumGroup = null)
        {
            string id = SpotifyId.Encode(SpotifyIdType.Album, album.Id);

            return new SimplifiedAlbumObject
            {
                TotalTracks = album.Songs.Count,
                AvailableMarkets = SpotifyMetadata.AvailableMarkets,
                ExternalUrls = ExternalUrls("album", id),
                Href = $"{_baseUrl}/v1/albums/{id}",
                Id = id,
                Images = Images(album.ImageUrl, 640, 300, 64),
                Name = album.Name,
                ReleaseDate = SpotifyMetadata.ReleaseDate(album.Id),
                Uri = $"spotify:album:{id}",
                Artists = [ToSimplifiedArtistObject(album.Artist)],
                AlbumGroup = albumGroup
            };
        }

        public AlbumObject ToAlbumObject(Album album)
        {
            string id = SpotifyId.Encode(SpotifyIdType.Album, album.Id);
            List<Song> songs = [.. album.Songs.OrderBy(s => s.Id)];

            return new AlbumObject
            {
                TotalTracks = songs.Count,
                AvailableMarkets = SpotifyMetadata.AvailableMarkets,
                ExternalUrls = ExternalUrls("album", id),
                Href = $"{_baseUrl}/v1/albums/{id}",
                Id = id,
                Images = Images(album.ImageUrl, 640, 300, 64),
                Name = album.Name,
                ReleaseDate = SpotifyMetadata.ReleaseDate(album.Id),
                Uri = $"spotify:album:{id}",
                Artists = [ToSimplifiedArtistObject(album.Artist)],
                Tracks = SpotifyPaging.Create(
                    songs.Select((song, index) => ToSimplifiedTrackObject(song, index + 1)),
                    limit: 50,
                    offset: 0,
                    total: songs.Count,
                    hrefBuilder: (offset, limit) => $"{_baseUrl}/v1/albums/{id}/tracks?offset={offset}&limit={limit}"),
                Copyrights =
                [
                    new CopyrightObject { Text = $"© {SpotifyMetadata.ReleaseDate(album.Id)[..4]} {SpotifyMetadata.Label(album.Id)}", Type = "C" },
                    new CopyrightObject { Text = $"℗ {SpotifyMetadata.ReleaseDate(album.Id)[..4]} {SpotifyMetadata.Label(album.Id)}", Type = "P" }
                ],
                ExternalIds = new ExternalIdsObject { Upc = SpotifyMetadata.Upc(album.Id) },
                Genres = [],
                Label = SpotifyMetadata.Label(album.Id),
                Popularity = SpotifyMetadata.Popularity(SpotifyIdType.Album, album.Id)
            };
        }

        #endregion

        #region Chansons

        public SimplifiedTrackObject ToSimplifiedTrackObject(Song song, int trackNumber)
        {
            string id = SpotifyId.Encode(SpotifyIdType.Track, song.Id);

            return new SimplifiedTrackObject
            {
                Artists = [ToSimplifiedArtistObject(song.Album.Artist)],
                AvailableMarkets = SpotifyMetadata.AvailableMarkets,
                DurationMs = SpotifyMetadata.DurationMs(song.Id),
                Explicit = false,
                ExternalUrls = ExternalUrls("track", id),
                Href = $"{_baseUrl}/v1/tracks/{id}",
                Id = id,
                IsLocal = false,
                Name = song.Name,
                PreviewUrl = null,
                TrackNumber = trackNumber,
                Uri = $"spotify:track:{id}"
            };
        }

        public TrackObject ToTrackObject(Song song)
        {
            string id = SpotifyId.Encode(SpotifyIdType.Track, song.Id);

            return new TrackObject
            {
                Album = ToSimplifiedAlbumObject(song.Album),
                Artists = [ToSimplifiedArtistObject(song.Album.Artist)],
                AvailableMarkets = SpotifyMetadata.AvailableMarkets,
                DurationMs = SpotifyMetadata.DurationMs(song.Id),
                Explicit = false,
                ExternalIds = new ExternalIdsObject { Isrc = SpotifyMetadata.Isrc(song.Id) },
                ExternalUrls = ExternalUrls("track", id),
                Href = $"{_baseUrl}/v1/tracks/{id}",
                Id = id,
                IsLocal = false,
                Name = song.Name,
                Popularity = SpotifyMetadata.Popularity(SpotifyIdType.Track, song.Id),
                PreviewUrl = null,
                TrackNumber = TrackNumber(song),
                Uri = $"spotify:track:{id}"
            };
        }

        /// <summary>Position d'une chanson à l'intérieur de son album.</summary>
        public static int TrackNumber(Song song)
        {
            return song.Album.Songs.OrderBy(s => s.Id).ToList().FindIndex(s => s.Id == song.Id) + 1;
        }

        #endregion

        /// <summary>
        /// Spotify fournit chaque image en trois formats. Le serveur maison n'en possède
        /// qu'un seul : la même adresse est donc répétée trois fois.
        /// </summary>
        private static ImageObject[] Images(string url, params int[] sizes)
        {
            return [.. sizes.Select(size => new ImageObject { Url = url, Height = size, Width = size })];
        }

        private static ExternalUrlsObject ExternalUrls(string type, string id)
        {
            return new ExternalUrlsObject { Spotify = $"https://open.spotify.com/{type}/{id}" };
        }
    }
}
