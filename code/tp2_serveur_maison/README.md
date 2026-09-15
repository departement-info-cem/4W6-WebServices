# 🏠 Serveur maison du TP2

Ce serveur imite l'API Web de **Spotify** : il répond aux mêmes routes, retourne les mêmes
objets JSON et produit les mêmes messages d'erreur. Pour passer de Spotify au serveur maison,
il suffit donc de changer l'**adresse** des requêtes.

| Spotify                                  | Serveur maison                      |
|:-----------------------------------------|:------------------------------------|
| `https://accounts.spotify.com/api/token` | `http://localhost:5143/api/token`   |
| `https://api.spotify.com/v1/...`         | `http://localhost:5143/v1/...`      |

## ▶ Exécuter le serveur

Dans le dossier `TP2_serveur` :

```
dotnet ef database update
dotnet run
```

## 🔑 CLIENT_ID et CLIENT_SECRET

Le serveur maison n'a pas de tableau de bord développeur : les identifiants sont codés en dur
dans [`TP2_serveur/Spotify/SpotifyCredentials.cs`](TP2_serveur/Spotify/SpotifyCredentials.cs).

```ts
const CLIENT_ID = "4a9b2c7d1e0f3a8b5c6d7e8f9a0b1c2d";
const CLIENT_SECRET = "9f8e7d6c5b4a39281706152433425160";
```

## 📶 Les 4 requêtes du TP2

Le code est **exactement** celui des notes de cours ; seule l'adresse change.

### Connexion

```ts
const response = await axios.post("http://localhost:5143/api/token",
  new URLSearchParams({ grant_type : "client_credentials" }), {
  headers : {
    "Content-Type" : "application/x-www-form-urlencoded",
    "Authorization" : "Basic " + btoa(CLIENT_ID + ":" + CLIENT_SECRET)
  }});

localStorage.setItem("token", response.data.access_token);
```

### Artiste, albums et chansons

```ts
// response.data.artists.items[0] → id, name, images[0].url
await spotifyRequest.get("http://localhost:5143/v1/search?type=artist&offset=0&limit=1&q=" + artistName);

// response.data.items[i] → id, name, images[0].url
await spotifyRequest.get("http://localhost:5143/v1/artists/" + artistId + "/albums?include_groups=album,single");

// response.data.tracks.items[i] → name
await spotifyRequest.get("http://localhost:5143/v1/albums/" + albumId);
```

## 📚 Routes disponibles

| Route                            | Description                                      |
|:---------------------------------|:-------------------------------------------------|
| `POST /api/token`                | Requête de connexion (`grant_type=client_credentials`) |
| `GET /v1/search`                 | Recherche (`q`, `type`, `limit`, `offset`)        |
| `GET /v1/artists/{id}`           | Un artiste                                        |
| `GET /v1/artists?ids=`           | Plusieurs artistes                                |
| `GET /v1/artists/{id}/albums`    | Les albums d'un artiste (`include_groups`)        |
| `GET /v1/albums/{id}`            | Un album **et ses chansons** (`tracks.items`)     |
| `GET /v1/albums?ids=`            | Plusieurs albums                                  |
| `GET /v1/albums/{id}/tracks`     | Les chansons d'un album                           |
| `GET /v1/tracks/{id}`            | Une chanson                                       |

Les identifiants ont la même forme que ceux de Spotify : 22 caractères en base 62,
par exemple `4Us5ppYG7GYvtbhJLcMX4s`.

## ⛔ Erreurs

Comme chez Spotify, la requête de connexion et les requêtes `/v1/...` n'utilisent pas le
même format d'erreur.

**`POST /api/token`** — toujours un code `400` :

| Situation                            | Réponse                                                                 |
|:-------------------------------------|:------------------------------------------------------------------------|
| CLIENT_ID inconnu ou en-tête absent  | `{"error":"invalid_client","error_description":"Invalid client"}`        |
| CLIENT_SECRET incorrect              | `{"error":"invalid_client","error_description":"Invalid client secret"}` |
| `grant_type` absent                  | `{"error":"unsupported_grant_type","error_description":"grant_type parameter is missing"}` |
| `grant_type` inconnu                 | `{"error":"unsupported_grant_type","error_description":"grant_type must be client_credentials, authorization_code or refresh_token"}` |

**`GET /v1/...`** — `{"error":{"status":..., "message":"..."}}` :

| Situation                              | Code | Message                                     |
|:---------------------------------------|:-----|:---------------------------------------------|
| Aucun en-tête `Authorization`          | 401  | `No token provided`                          |
| En-tête qui n'est pas un `Bearer`      | 400  | `Only valid bearer authentication supported` |
| Token illisible ou mal signé           | 401  | `Invalid access token`                       |
| Token expiré (après 1 heure)           | 401  | `The access token expired`                   |
| Identifiant qui n'a pas 22 caractères  | 400  | `Invalid base62 id`                          |
| Identifiant inconnu                    | 404  | `Non existing id`                            |
| Recherche sans `q`                     | 400  | `No search query`                            |
| Recherche sans `type`                  | 400  | `Missing parameter type`                     |
| `type` inconnu                         | 400  | `Bad search type field XXX`                  |
| `limit` hors de 1 à 50                 | 400  | `Invalid limit`                              |
| `offset` hors de 0 à 1000              | 400  | `Invalid offset`                             |
| Route inexistante                      | 404  | `Service not found`                          |

## 🕰 Anciennes routes

Les routes de la première version du serveur maison (`/api/Users/Login`,
`/api/Artists/GetArtist/{nom}`, `/api/Albums/GetAlbums/{id}` et `/api/Songs/GetSongs/{id}`)
fonctionnent toujours exactement comme avant.

## 🎨 Contenu de la base de données

* 5 artistes : Hans Zimmer, The Weeknd, Drake, Lady Gaga et Beyoncé
* 20 albums (4 par artiste)
* 60 chansons (3 par album)

Les informations que le serveur maison ne possède pas (popularité, nombre d'abonnés, date de
sortie, durée des chansons, etc.) sont inventées, mais toujours de la même façon : un album
aura donc toujours la même date de sortie d'une requête à l'autre.
