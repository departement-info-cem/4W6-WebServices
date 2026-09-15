using System.Buffers.Binary;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace TP2_serveur.Spotify
{
    /// <summary>Les trois sortes d'objets identifiables du serveur maison.</summary>
    public enum SpotifyIdType
    {
        Artist,
        Album,
        Track
    }

    /// <summary>
    /// Traduit les identifiants numériques de la base de données en identifiants
    /// « à la Spotify » : 22 caractères en base 62 (0-9, A-Z, a-z), par exemple
    /// <c>0YC192cP3KPCRWx8zr8MfZ</c>.
    ///
    /// L'encodage est réversible : on peut donc retrouver l'entier d'origine sans
    /// avoir à ranger quoi que ce soit dans la base de données. Les 12 premiers octets
    /// proviennent d'un hachage (pour que l'id ait l'air aléatoire et qu'un id d'album
    /// ne puisse pas être utilisé comme id d'artiste) et les 4 derniers contiennent
    /// l'entier lui-même.
    /// </summary>
    public static class SpotifyId
    {
        private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        /// <summary>Longueur d'un identifiant Spotify.</summary>
        public const int Length = 22;

        /// <summary>Fabrique l'identifiant Spotify correspondant à un id de la base de données.</summary>
        public static string Encode(SpotifyIdType type, int id)
        {
            byte[] bytes = new byte[16];

            // 12 premiers octets : un hachage du type et de l'id (pour brouiller les pistes)
            byte[] hash = SHA256.HashData(Encoding.UTF8.GetBytes($"4W6:{type}:{id}"));
            hash.AsSpan(0, 12).CopyTo(bytes);

            // 4 derniers octets : l'id lui-même, ce qui rend l'encodage réversible
            BinaryPrimitives.WriteInt32BigEndian(bytes.AsSpan(12), id);

            return ToBase62(new BigInteger(bytes, isUnsigned: true, isBigEndian: true));
        }

        /// <summary>
        /// Vérifie qu'une chaîne a la forme d'un identifiant Spotify : exactement 22 caractères
        /// en base 62. (Spotify répond « Invalid base62 id » lorsque ce n'est pas le cas.)
        /// </summary>
        public static bool IsWellFormed(string? value)
        {
            if (value == null || value.Length != Length) return false;

            foreach (char c in value)
            {
                if (!Alphabet.Contains(c)) return false;
            }

            return true;
        }

        /// <summary>
        /// Retrouve l'id de la base de données à partir d'un identifiant Spotify.
        /// Retourne <c>false</c> si l'identifiant ne correspond pas au type demandé.
        /// </summary>
        public static bool TryDecode(string? value, SpotifyIdType type, out int id)
        {
            id = 0;

            if (!IsWellFormed(value)) return false;

            BigInteger number = BigInteger.Zero;
            foreach (char c in value!)
            {
                number = number * 62 + Alphabet.IndexOf(c);
            }

            byte[] digits = number.ToByteArray(isUnsigned: true, isBigEndian: true);
            if (digits.Length > 16) return false;

            // On complète avec des zéros à gauche pour toujours obtenir 16 octets
            byte[] bytes = new byte[16];
            digits.CopyTo(bytes, 16 - digits.Length);

            int decoded = BinaryPrimitives.ReadInt32BigEndian(bytes.AsSpan(12));
            if (decoded <= 0) return false;

            // On réencode : si on retombe sur le même identifiant, c'est qu'il est authentique
            if (Encode(type, decoded) != value) return false;

            id = decoded;
            return true;
        }

        private static string ToBase62(BigInteger value)
        {
            char[] digits = new char[Length];

            for (int i = Length - 1; i >= 0; i--)
            {
                value = BigInteger.DivRem(value, 62, out BigInteger remainder);
                digits[i] = Alphabet[(int)remainder];
            }

            return new string(digits);
        }
    }
}
