---
title: "5.1 - TP2 (20%) 🔨"
---

import Tabs from '@theme/Tabs';
import TabItem from '@theme/TabItem';

Les instructions du TP2 sont [ici](/tp/tp2).

## 🏠 Serveur maison pour le TP2

:::warning

Le TP2 n'est ni plus facile, ni plus difficile en utilisant le **serveur maison**. Cela dit, cela permet de ne pas avoir à payer pour **Spotify**.

:::

💾 Téléchargement : [Cliquez-ici](https://github.com/departement-info-cem/4W6-WebServices/releases/latest/download/code-tp2_serveur_maison.zip)

Si vous n'êtes pas abonné(e) à **Spotify**, utilisez simplement ce **serveur maison** que vous exécuterez localement.

Il fera le même travail que l'API de Spotify : il vous donnera accès à quelques **artistes**, **albums** et **chansons**.

Puisque ce serveur est fait maison à la dernière minute, il contient **très peu de données** :

* 5 artistes (Hans Zimmer, The Weeknd, Drake, Lady Gaga et Beyoncé)
* 20 albums (4 par artiste)
* 60 chansons (3 par album)

Cependant, c'est **amplement suffisant** pour réaliser le TP.

:::tip

🎉 Le serveur maison **imite l'API de Spotify** : mêmes requêtes, mêmes objets JSON et mêmes messages d'erreur.

Vous pouvez donc utiliser le code du [Cours 4.1](/notes/rencontre4.1#-exemples-de-requêtes-à-spotify-pour-le-tp2) **tel quel** : il suffit de **changer l'adresse** des requêtes !

|Spotify|Serveur maison|
|:-|:-|
|`https://accounts.spotify.com/api/token`|`http://localhost:5143/api/token`|
|`https://api.spotify.com/v1/...`|`http://localhost:5143/v1/...`|

🪄 Chaque exemple de code ci-dessous possède un **onglet par API**. Votre choix est conservé partout dans les notes de cours !

:::

:::danger

🚔🚨🔥 Si vous utilisez ce **serveur maison** pour faire le **TP2**, il ne doit pas être remis. Seul le projet **Next.js** est évalué !

:::

### ▶ Exécuter le serveur

Pour pouvoir envoyer des requêtes au serveur, il faut l'exécuter sur votre ordinateur. (Comme pendant le laboratoire 6)

**Étape 1** : Créez la base de données. Situez vous dans le dossier `/tp2_serveur_maison/TP2_serveur`, lancez **PowerShell** et faites la commande :

`dotnet ef database update`

**Étape 2** : Exécutez le serveur. Toujours avec la même fenêtre **PowerShell**, faites la commande :

`dotnet run`

Ne fermez pas la fenêtre **PowerShell**, sinon le serveur s'éteindra.

:::note

Ces deux étapes doivent être répétées à chaque fois que vous changez d'ordinateur. Si jamais vous arrêtez l'exécution du serveur, mais restez sur le même ordinateur, seule l'étape 2 doit être répétée.

Si vous êtes sur votre ordinateur personnel, il est possible que vous deviez installer ceci :

`dotnet tool install --global dotnet-ef`

:::

## 📦 Classes utiles

Voici deux classes qui pourraient vous être utiles dans le contexte du **TP2** (N'oubliez pas de les isoler chacune dans leur propre fichier !) :

```ts showLineNumbers
export class Artist{
  constructor(public id : string, public name : string, public imageUrl : string){}
}

export class Album{
  constructor(public id : string, public name : string, public image : string){}
}
```

## 🕵️‍♂️ Client ID et Client Secret

Il faut un **Client ID** et un **Client Secret**, exactement comme pour **Spotify**.

Le serveur maison, lui, n'a pas de tableau de bord développeur : ses deux valeurs sont donc **toujours les mêmes** et vous pouvez les **hard-coder** tout de suite.

<Tabs groupId="api-musique">
    <TabItem value="spotify" label="🎧 Spotify">
```tsx showLineNumbers
// Déclarées à l'extérieur comme ça elles ne sont pas réinitialisée à chaque fois que le composant est chargé
// Ces deux valeurs proviennent de votre tableau de bord Spotify
const CLIENT_ID = "098gf0fd987gdf89g7sd7g9sd";
const CLIENT_SECRET = "9dsh79d8m7j9ds7b97nber978675";
```
    </TabItem>
    <TabItem value="maison" label="🏠 Serveur maison" default>
```tsx showLineNumbers
// Déclarées à l'extérieur comme ça elles ne sont pas réinitialisée à chaque fois que le composant est chargé
const CLIENT_ID = "4a9b2c7d1e0f3a8b5c6d7e8f9a0b1c2d";
const CLIENT_SECRET = "9f8e7d6c5b4a39281706152433425160";
```
    </TabItem>
</Tabs>

## 🔑 Requête de connexion

Exactement la même requête que pour **Spotify** : seule l'**adresse** a changé.

<Tabs groupId="api-musique">
    <TabItem value="spotify" label="🎧 Spotify">
```tsx showLineNumbers
async function connect(){

  // Attention ! Pour une fois, on utilise une requête POST
  const response = await axios.post("https://accounts.spotify.com/api/token",
    new URLSearchParams({ grant_type : "client_credentials" }), {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Basic " + btoa(CLIENT_ID + ":" + CLIENT_SECRET)
    }});
  console.log(response.data);

  setToken(response.data.access_token); // Le token peut être rangé dans un état ...
  localStorage.setItem("token", response.data.access_token); // ... ou dans le stockage local.

}
```
    </TabItem>
    <TabItem value="maison" label="🏠 Serveur maison" default>
```tsx showLineNumbers
async function connect(){

  // Attention ! Pour une fois, on utilise une requête POST
  const response = await axios.post("http://localhost:5143/api/token",
    new URLSearchParams({ grant_type : "client_credentials" }), {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Basic " + btoa(CLIENT_ID + ":" + CLIENT_SECRET)
    }});
  console.log(response.data);

  setToken(response.data.access_token); // Le token peut être rangé dans un état ...
  localStorage.setItem("token", response.data.access_token); // ... ou dans le stockage local.

}
```
    </TabItem>
</Tabs>

:::tip

📶 L'**intercepteur** du [Cours 4.1](/notes/rencontre4.1#-intercepteurs) fonctionne de la même façon avec le serveur maison : il n'y a rien à y changer.

:::

## 👨‍🎨 Obtenir un artiste

<Tabs groupId="api-musique">
    <TabItem value="spotify" label="🎧 Spotify">
```tsx showLineNumbers
async function getArtist(artistName : string){

  const response = await axios.get("https://api.spotify.com/v1/search?type=artist&offset=0&limit=1&q=" + artistName, {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Bearer " + token // 🔑 Votre token de connexion
    }
  });
  console.log(response.data);

  return new Artist(response.data.artists.items[0].id, response.data.artists.items[0].name, response.data.artists.items[0].images[0].url);

}
```
    </TabItem>
    <TabItem value="maison" label="🏠 Serveur maison" default>
```tsx showLineNumbers
async function getArtist(artistName : string){

  const response = await axios.get("http://localhost:5143/v1/search?type=artist&offset=0&limit=1&q=" + artistName, {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Bearer " + token // 🔑 Votre token de connexion
    }
  });
  console.log(response.data);

  return new Artist(response.data.artists.items[0].id, response.data.artists.items[0].name, response.data.artists.items[0].images[0].url);

}
```
    </TabItem>
</Tabs>

:::warning

Le serveur maison ne connaît que **5 artistes**. Si vous cherchez un artiste qu'il ne connaît pas, `response.data.artists.items` sera un tableau **vide** : il n'y aura donc pas de `items[0]` !

:::

## 💿 Obtenir les albums d'un artiste

Vous aurez besoin de l'**id** de l'artiste, pas de son **nom**.

<Tabs groupId="api-musique">
    <TabItem value="spotify" label="🎧 Spotify">
```tsx showLineNumbers
async function getAlbums(artistId : string){

  const response = await axios.get("https://api.spotify.com/v1/artists/" + artistId + "/albums?include_groups=album,single", {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Bearer " + token // 🔑 Votre token de connexion
    }
  });
  console.log(response.data);

  let albums : Album[] = [];
  for(let i = 0; i < response.data.items.length; i++){
    albums.push(new Album(response.data.items[i].id, response.data.items[i].name, response.data.items[i].images[0].url));
  }
  return albums;

}
```
    </TabItem>
    <TabItem value="maison" label="🏠 Serveur maison" default>
```tsx showLineNumbers
async function getAlbums(artistId : string){

  const response = await axios.get("http://localhost:5143/v1/artists/" + artistId + "/albums?include_groups=album,single", {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Bearer " + token // 🔑 Votre token de connexion
    }
  });
  console.log(response.data);

  let albums : Album[] = [];
  for(let i = 0; i < response.data.items.length; i++){
    albums.push(new Album(response.data.items[i].id, response.data.items[i].name, response.data.items[i].images[0].url));
  }
  return albums;

}
```
    </TabItem>
</Tabs>

## 🎵 Obtenir les chansons d'un album

Vous aurez besoin de l'**id** de l'album, pas de son **nom**.

<Tabs groupId="api-musique">
    <TabItem value="spotify" label="🎧 Spotify">
```tsx showLineNumbers
async function getSongs(albumId : string){

  const response = await axios.get("https://api.spotify.com/v1/albums/" + albumId, {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Bearer " + token // 🔑 Votre token de connexion
    }
  });
  console.log(response.data);

  let songs : string[] = [];
  for(let i = 0; i < response.data.tracks.items.length; i++){
    songs.push(response.data.tracks.items[i].name);
  }
  return songs;

}
```
    </TabItem>
    <TabItem value="maison" label="🏠 Serveur maison" default>
```tsx showLineNumbers
async function getSongs(albumId : string){

  const response = await axios.get("http://localhost:5143/v1/albums/" + albumId, {
    headers : {
      "Content-Type" : "application/x-www-form-urlencoded",
      "Authorization" : "Bearer " + token // 🔑 Votre token de connexion
    }
  });
  console.log(response.data);

  let songs : string[] = [];
  for(let i = 0; i < response.data.tracks.items.length; i++){
    songs.push(response.data.tracks.items[i].name);
  }
  return songs;

}
```
    </TabItem>
</Tabs>

## ⛔ Erreurs fréquentes

Le serveur maison répond les mêmes erreurs que **Spotify**. Si une requête ne fonctionne pas, regardez le message dans la **console** 🔍 :

|Message|Ce qui s'est passé|
|:-|:-|
|`No token provided`|Vous avez oublié l'en-tête `Authorization` dans votre requête.|
|`Invalid access token`|Votre token est illisible. (Souvent parce qu'il est `null` : avez-vous bien attendu la fin de la requête de connexion ?)|
|`The access token expired`|Votre token a plus d'une heure : reconnectez-vous !|
|`Only valid bearer authentication supported`|Vous avez écrit autre chose que `"Bearer " + token`.|
|`Invalid base62 id`|L'id envoyé n'est pas un id valide. (Ils font tous 22 caractères)|
|`Non existing id`|L'id envoyé est valide, mais aucun artiste / album ne lui correspond.|
|`invalid_client`|Votre `CLIENT_ID` ou votre `CLIENT_SECRET` contient une faute de frappe.|

## 🎥🗺 YouTube et BandsInTown

Pour les requêtes à **YouTube** et **BandsInTown**, il n'y a pas de changement : comme les utilisateurs de Spotify, vous pourrez communiquer avec ces deux autres APIs en vous référant aux notes de cours et à l'énoncé du TP2.
