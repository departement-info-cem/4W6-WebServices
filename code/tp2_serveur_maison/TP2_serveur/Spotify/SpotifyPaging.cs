using TP2_serveur.DTOs.Spotify;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Outils de pagination : Spotify découpe toujours ses résultats en pages
    /// contrôlées par les paramètres <c>limit</c> et <c>offset</c>.
    /// </summary>
    public static class SpotifyPaging
    {
        /// <summary>Valeurs acceptées par Spotify pour le paramètre limit.</summary>
        public const int MinLimit = 1;
        public const int MaxLimit = 50;

        /// <summary>Valeur maximale acceptée par Spotify pour le paramètre offset.</summary>
        public const int MaxOffset = 1000;

        /// <summary>
        /// Construit une page de résultats. Les liens <c>next</c> et <c>previous</c> sont
        /// fabriqués par <paramref name="hrefBuilder"/>, qui reçoit un offset et une limite.
        /// </summary>
        public static PagingObject<T> Create<T>(IEnumerable<T> items, int limit, int offset, int total, Func<int, int, string> hrefBuilder)
        {
            return new PagingObject<T>
            {
                Href = hrefBuilder(offset, limit),
                Items = items,
                Limit = limit,
                Next = offset + limit < total ? hrefBuilder(offset + limit, limit) : null,
                Offset = offset,
                Previous = offset > 0 ? hrefBuilder(Math.Max(0, offset - limit), limit) : null,
                Total = total
            };
        }

        /// <summary>
        /// Lit le paramètre limit d'une requête. Retourne <c>false</c> si la valeur reçue
        /// n'est pas un nombre entre 1 et 50, ce que Spotify refuse.
        /// </summary>
        public static bool TryParseLimit(string? value, int defaultValue, out int limit)
        {
            limit = defaultValue;

            if (string.IsNullOrEmpty(value)) return true;
            if (!int.TryParse(value, out int parsed) || parsed < MinLimit || parsed > MaxLimit) return false;

            limit = parsed;
            return true;
        }

        /// <summary>Lit le paramètre offset d'une requête. (Entre 0 et 1000 chez Spotify)</summary>
        public static bool TryParseOffset(string? value, out int offset)
        {
            offset = 0;

            if (string.IsNullOrEmpty(value)) return true;
            if (!int.TryParse(value, out int parsed) || parsed < 0 || parsed > MaxOffset) return false;

            offset = parsed;
            return true;
        }
    }
}
