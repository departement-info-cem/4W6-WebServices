using System.Globalization;
using System.Text;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Outils servant à la recherche de /v1/search. La comparaison ignore la casse et les
    /// accents : chercher « beyonce » trouve donc bel et bien « Beyoncé ».
    /// </summary>
    public static class SpotifySearch
    {
        /// <summary>
        /// Les types acceptés par Spotify dans le paramètre « type ». Le serveur maison ne
        /// possède que des artistes, des albums et des chansons : les autres types sont
        /// acceptés, mais ne retournent jamais de résultat.
        /// </summary>
        public static readonly string[] ValidTypes = ["album", "artist", "audiobook", "episode", "playlist", "show", "track"];

        /// <summary>Vrai si le nom contient les mots recherchés.</summary>
        public static bool Matches(string name, string query)
        {
            return Normalize(name).Contains(Normalize(query));
        }

        /// <summary>
        /// Sert à placer les meilleurs résultats en premier : un nom identique à la
        /// recherche passe avant un nom qui commence par la recherche, qui passe lui-même
        /// avant un nom qui la contient simplement.
        /// </summary>
        public static int Rank(string name, string query)
        {
            string normalizedName = Normalize(name);
            string normalizedQuery = Normalize(query);

            if (normalizedName == normalizedQuery) return 0;
            if (normalizedName.StartsWith(normalizedQuery)) return 1;

            return 2;
        }

        /// <summary>Met un texte en minuscules et lui retire ses accents.</summary>
        private static string Normalize(string value)
        {
            StringBuilder builder = new StringBuilder();

            foreach (char c in value.Normalize(NormalizationForm.FormD))
            {
                if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark) builder.Append(c);
            }

            return builder.ToString().Normalize(NormalizationForm.FormC).Trim().ToLowerInvariant();
        }
    }
}
