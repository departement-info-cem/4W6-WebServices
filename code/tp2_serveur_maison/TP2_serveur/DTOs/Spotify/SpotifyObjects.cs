using System.Text.Json.Serialization;

namespace TP2_serveur.DTOs.Spotify
{
    /// <summary>Une image (pochette d'album ou photo d'artiste).</summary>
    public class ImageObject
    {
        [JsonPropertyName("url")]
        public string Url { get; init; } = null!;

        [JsonPropertyName("height")]
        public int? Height { get; init; }

        [JsonPropertyName("width")]
        public int? Width { get; init; }
    }

    /// <summary>Les liens « grand public » d'un objet. (Page Web de Spotify)</summary>
    public class ExternalUrlsObject
    {
        [JsonPropertyName("spotify")]
        public string Spotify { get; init; } = null!;
    }

    public class FollowersObject
    {
        [JsonPropertyName("href")]
        public string? Href { get; init; }

        [JsonPropertyName("total")]
        public int Total { get; init; }
    }

    public class ExternalIdsObject
    {
        [JsonPropertyName("upc")]
        public string? Upc { get; init; }

        [JsonPropertyName("isrc")]
        public string? Isrc { get; init; }
    }

    public class CopyrightObject
    {
        [JsonPropertyName("text")]
        public string Text { get; init; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; init; } = null!;
    }

    /// <summary>Artiste réduit : c'est cette version qu'on retrouve à l'intérieur des albums et des chansons.</summary>
    public class SimplifiedArtistObject
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrlsObject ExternalUrls { get; init; } = null!;

        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("type")]
        public string Type { get; init; } = "artist";

        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;
    }

    /// <summary>Artiste complet : c'est ce que retourne /v1/search?type=artist et /v1/artists/{id}.</summary>
    public class ArtistObject
    {
        [JsonPropertyName("external_urls")]
        public ExternalUrlsObject ExternalUrls { get; init; } = null!;

        [JsonPropertyName("followers")]
        public FollowersObject Followers { get; init; } = null!;

        [JsonPropertyName("genres")]
        public string[] Genres { get; init; } = [];

        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("images")]
        public ImageObject[] Images { get; init; } = [];

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("popularity")]
        public int Popularity { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; } = "artist";

        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;
    }

    /// <summary>Album réduit : c'est cette version que retourne /v1/artists/{id}/albums.</summary>
    public class SimplifiedAlbumObject
    {
        [JsonPropertyName("album_type")]
        public string AlbumType { get; init; } = "album";

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; init; }

        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; init; } = [];

        [JsonPropertyName("external_urls")]
        public ExternalUrlsObject ExternalUrls { get; init; } = null!;

        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("images")]
        public ImageObject[] Images { get; init; } = [];

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; init; } = null!;

        [JsonPropertyName("release_date_precision")]
        public string ReleaseDatePrecision { get; init; } = "day";

        [JsonPropertyName("type")]
        public string Type { get; init; } = "album";

        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;

        [JsonPropertyName("artists")]
        public SimplifiedArtistObject[] Artists { get; init; } = [];

        /// <summary>Présent uniquement dans /v1/artists/{id}/albums (lié à include_groups).</summary>
        [JsonPropertyName("album_group")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? AlbumGroup { get; init; }
    }

    /// <summary>Album complet : c'est ce que retourne /v1/albums/{id}, avec ses chansons.</summary>
    public class AlbumObject
    {
        [JsonPropertyName("album_type")]
        public string AlbumType { get; init; } = "album";

        [JsonPropertyName("total_tracks")]
        public int TotalTracks { get; init; }

        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; init; } = [];

        [JsonPropertyName("external_urls")]
        public ExternalUrlsObject ExternalUrls { get; init; } = null!;

        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("images")]
        public ImageObject[] Images { get; init; } = [];

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; init; } = null!;

        [JsonPropertyName("release_date_precision")]
        public string ReleaseDatePrecision { get; init; } = "day";

        [JsonPropertyName("type")]
        public string Type { get; init; } = "album";

        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;

        [JsonPropertyName("artists")]
        public SimplifiedArtistObject[] Artists { get; init; } = [];

        /// <summary>Les chansons de l'album : c'est ici que se trouve tracks.items !</summary>
        [JsonPropertyName("tracks")]
        public PagingObject<SimplifiedTrackObject> Tracks { get; init; } = null!;

        [JsonPropertyName("copyrights")]
        public CopyrightObject[] Copyrights { get; init; } = [];

        [JsonPropertyName("external_ids")]
        public ExternalIdsObject ExternalIds { get; init; } = null!;

        [JsonPropertyName("genres")]
        public string[] Genres { get; init; } = [];

        [JsonPropertyName("label")]
        public string Label { get; init; } = null!;

        [JsonPropertyName("popularity")]
        public int Popularity { get; init; }
    }

    /// <summary>Chanson réduite : c'est cette version qu'on retrouve dans tracks.items d'un album.</summary>
    public class SimplifiedTrackObject
    {
        [JsonPropertyName("artists")]
        public SimplifiedArtistObject[] Artists { get; init; } = [];

        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; init; } = [];

        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; init; } = 1;

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; init; }

        [JsonPropertyName("explicit")]
        public bool Explicit { get; init; }

        [JsonPropertyName("external_urls")]
        public ExternalUrlsObject ExternalUrls { get; init; } = null!;

        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("is_local")]
        public bool IsLocal { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; init; }

        [JsonPropertyName("track_number")]
        public int TrackNumber { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; } = "track";

        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;
    }

    /// <summary>Chanson complète : c'est ce que retournent /v1/tracks/{id} et /v1/search?type=track.</summary>
    public class TrackObject
    {
        [JsonPropertyName("album")]
        public SimplifiedAlbumObject Album { get; init; } = null!;

        [JsonPropertyName("artists")]
        public SimplifiedArtistObject[] Artists { get; init; } = [];

        [JsonPropertyName("available_markets")]
        public string[] AvailableMarkets { get; init; } = [];

        [JsonPropertyName("disc_number")]
        public int DiscNumber { get; init; } = 1;

        [JsonPropertyName("duration_ms")]
        public int DurationMs { get; init; }

        [JsonPropertyName("explicit")]
        public bool Explicit { get; init; }

        [JsonPropertyName("external_ids")]
        public ExternalIdsObject ExternalIds { get; init; } = null!;

        [JsonPropertyName("external_urls")]
        public ExternalUrlsObject ExternalUrls { get; init; } = null!;

        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("id")]
        public string Id { get; init; } = null!;

        [JsonPropertyName("is_local")]
        public bool IsLocal { get; init; }

        [JsonPropertyName("name")]
        public string Name { get; init; } = null!;

        [JsonPropertyName("popularity")]
        public int Popularity { get; init; }

        [JsonPropertyName("preview_url")]
        public string? PreviewUrl { get; init; }

        [JsonPropertyName("track_number")]
        public int TrackNumber { get; init; }

        [JsonPropertyName("type")]
        public string Type { get; init; } = "track";

        [JsonPropertyName("uri")]
        public string Uri { get; init; } = null!;
    }

    /// <summary>
    /// Une « page » de résultats. Spotify ne renvoie jamais tous les résultats d'un coup :
    /// il faut se promener dedans avec limit et offset.
    /// </summary>
    public class PagingObject<T>
    {
        [JsonPropertyName("href")]
        public string Href { get; init; } = null!;

        [JsonPropertyName("items")]
        public IEnumerable<T> Items { get; init; } = [];

        [JsonPropertyName("limit")]
        public int Limit { get; init; }

        [JsonPropertyName("next")]
        public string? Next { get; init; }

        [JsonPropertyName("offset")]
        public int Offset { get; init; }

        [JsonPropertyName("previous")]
        public string? Previous { get; init; }

        [JsonPropertyName("total")]
        public int Total { get; init; }
    }

    /// <summary>
    /// Réponse de /v1/search. Seuls les types demandés dans le paramètre « type »
    /// sont présents dans l'objet JSON retourné.
    /// </summary>
    public class SearchResponse
    {
        [JsonPropertyName("artists")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PagingObject<ArtistObject>? Artists { get; init; }

        [JsonPropertyName("albums")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PagingObject<SimplifiedAlbumObject>? Albums { get; init; }

        [JsonPropertyName("tracks")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public PagingObject<TrackObject>? Tracks { get; init; }
    }

    /// <summary>Réponse de /v1/artists?ids=...</summary>
    public class ArtistsResponse
    {
        [JsonPropertyName("artists")]
        public IEnumerable<ArtistObject?> Artists { get; init; } = [];
    }

    /// <summary>Réponse de /v1/albums?ids=...</summary>
    public class AlbumsResponse
    {
        [JsonPropertyName("albums")]
        public IEnumerable<AlbumObject?> Albums { get; init; } = [];
    }
}
