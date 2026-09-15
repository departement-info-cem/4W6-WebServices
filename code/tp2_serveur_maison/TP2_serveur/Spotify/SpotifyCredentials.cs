namespace TP2_serveur.Spotify
{
    /// <summary>
    /// Paramètres d'authentification du serveur maison.
    ///
    /// Sur Spotify, le CLIENT_ID et le CLIENT_SECRET proviennent du tableau de bord
    /// développeur (https://developer.spotify.com/dashboard). Le serveur maison n'a pas
    /// de tableau de bord : les deux valeurs sont donc simplement codées en dur ici.
    /// </summary>
    public static class SpotifyCredentials
    {
        /// <summary>Identifiant de l'application cliente. (En-tête « Basic » de POST /api/token)</summary>
        public const string ClientId = "4a9b2c7d1e0f3a8b5c6d7e8f9a0b1c2d";

        /// <summary>Secret de l'application cliente. (En-tête « Basic » de POST /api/token)</summary>
        public const string ClientSecret = "9f8e7d6c5b4a39281706152433425160";

        /// <summary>Phrase secrète servant à signer les tokens JWT.</summary>
        public const string SigningKey = "LooOOongue Phrase SiNoN Ça ne Marchera PaAaAAAaAas !";

        /// <summary>Émetteur des tokens. ⛔ Vérifiez le PORT de votre serveur dans launchSettings.json !</summary>
        public const string Issuer = "http://localhost:5143";

        /// <summary>Destinataire des tokens : l'application cliente.</summary>
        public const string Audience = "http://localhost:3000";

        /// <summary>Durée de validité d'un token, en secondes. (1 heure, comme Spotify)</summary>
        public const int TokenLifetimeSeconds = 3600;
    }
}
