using System.Security.Cryptography;
using System.Text;

namespace TP2_serveur.Spotify
{
    /// <summary>
    /// La base de données du serveur maison ne contient que des noms et des images. Or,
    /// Spotify renvoie aussi une popularité, un nombre d'abonnés, une durée, une date de
    /// sortie, etc.
    ///
    /// Ces informations sont donc inventées ici, mais de façon <b>déterministe</b> : un même
    /// album aura toujours exactement la même date de sortie, d'une requête à l'autre et
    /// d'une exécution du serveur à l'autre.
    /// </summary>
    public static class SpotifyMetadata
    {
        /// <summary>Quelques pays, comme dans le champ available_markets de Spotify.</summary>
        public static readonly string[] AvailableMarkets =
        [
            "AR", "AU", "BE", "BR", "CA", "CH", "DE", "DK", "ES", "FI",
            "FR", "GB", "IE", "IT", "JP", "MX", "NL", "NO", "NZ", "PT",
            "SE", "US"
        ];

        /// <summary>Popularité d'un objet, entre 0 et 100.</summary>
        public static int Popularity(SpotifyIdType type, int id, int min = 20, int max = 95)
        {
            return Random($"popularity:{type}:{id}").Next(min, max + 1);
        }

        /// <summary>Nombre d'abonnés d'un artiste.</summary>
        public static int Followers(int artistId)
        {
            return Random($"followers:{artistId}").Next(50_000, 40_000_000);
        }

        /// <summary>Durée d'une chanson, en millisecondes. (Entre 2 et 6 minutes)</summary>
        public static int DurationMs(int songId)
        {
            return Random($"duration:{songId}").Next(120_000, 360_000);
        }

        /// <summary>Date de sortie d'un album, au format aaaa-mm-jj.</summary>
        public static string ReleaseDate(int albumId)
        {
            Random random = Random($"release:{albumId}");
            DateTime start = new DateTime(2004, 1, 1);
            DateTime date = start.AddDays(random.Next(0, (DateTime.Today.Year - start.Year) * 365));

            return date.ToString("yyyy-MM-dd");
        }

        /// <summary>Maison de disque d'un album.</summary>
        public static string Label(int albumId)
        {
            string[] labels = ["Republic Records", "Columbia Records", "XO", "Interscope Records", "Parkwood Entertainment", "WaterTower Music"];

            return labels[Random($"label:{albumId}").Next(labels.Length)];
        }

        /// <summary>Code-barres (UPC) d'un album.</summary>
        public static string Upc(int albumId)
        {
            return Random($"upc:{albumId}").NextInt64(100_000_000_000, 999_999_999_999).ToString();
        }

        /// <summary>Code ISRC d'une chanson.</summary>
        public static string Isrc(int songId)
        {
            Random random = Random($"isrc:{songId}");

            return $"CA{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{(char)random.Next('A', 'Z' + 1)}{random.Next(10, 100)}{random.Next(100_000, 1_000_000)}";
        }

        /// <summary>
        /// Crée un générateur de nombres pseudo-aléatoires dont la graine dépend uniquement
        /// de la clé reçue : les mêmes valeurs seront donc toujours régénérées.
        /// </summary>
        private static Random Random(string key)
        {
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes(key));

            return new Random(BitConverter.ToInt32(hash, 0));
        }
    }
}
