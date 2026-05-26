---
title: "Cours 9 - TP2 (20%)"
---

Les instructions du TP2 sont [ici](/tp/tp2).

## 🏠 Serveur maison pour le TP2

:::warning

Le TP2 n'est ni plus facile, ni plus difficile en utilisant le **serveur maison**. Cela dit, cela permet de ne pas avoir à payer pour **Spotify**.

:::

💾 Téléchargement : [Cliquez-ici](../../static/files/tp2_serveur_maison.zip)

Si vous n'êtes pas abonné(e) à **Spotify**, utilisez simplement ce **serveur maison** que vous exécuterez localement.

Il fera le même travail que l'API de Spotify : il vous donnera accès à quelques **artistes**, **albums** et **chansons**.

Puisque ce serveur est fait maison à la dernière minute, il contient **très peu de données** :

* 5 artistes (Hans Zimmer, The Weeknd, Drake, Lady Gaga et Beyoncé)
* 20 albums (4 par artiste)
* 60 chansons (3 par album)

Cependant, c'est **amplement suffisant** pour réaliser le TP. Cela changera simplement **4 requêtes**, qui sont codées pour vous de toute façon.

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

## 🔑 Requête de connexion

```tsx showLineNumbers
async function connect(){

    // Vous devez utiliser les identifiants "abc" et "123".
    const response = await axios.post("http://localhost:5143/api/Users/Login", {
        username : "abc",
        password : "123"
    });
    console.log(response.data);

    setToken(response.data.token); // Le token peut-être rangé dans un état ...
    localStorage.setItem("token", response.data.token) // ... ou dans le stockage local.

}
```

## 👨‍🎨 Obtenir un artiste

```tsx showLineNumbers
async function getArtist(name : string){

    const response = await spotifyRequest.get("http://localhost:5143/api/Artists/GetArtist/" + name, {
        headers : {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token // 🔑 Votre token de connexion
        }
    });
    console.log(response.data);

    return new Artist(response.data.id, response.data.name, response.data.imageUrl);

}
```

## 💿 Obtenir les albums d'un artiste

Vous aurez besoin de l'**id** de l'artiste, pas de son **nom**.

```tsx showLineNumbers
async function getAlbums(artistId : string){

    const response = await spotifyRequest.get("http://localhost:5143/api/Albums/getAlbums/" + artistId, {
        headers : {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token // 🔑 Votre token de connexion
        }
    });
    console.log(response.data);

    let albums : Album[] = [];
    for(let a of response.data){
        albums.push(new Album(a.id, a.name, a.imageUrl));
    }

    return albums;

}
```

## 🎵 Obtenir les chansons d'un album

Vous aurez besoin de l'**id** de l'album, pas de son **nom**.

```tsx showLineNumbers
async function getSongs(albumId : string){

    const response = await spotifyRequest.get("http://localhost:5143/api/Songs/GetSongs/" + albumId, {
        headers : {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token // 🔑 Votre token de connexion
        }
    });
    console.log(response.data);

    let songs : string[] = [];
    for(let s of response.data) songs.push(s.name);

    return songs;

}
```

## 🎥🗺 YouTube et BandsInTown

Pour les requêtes à **YouTube** et **BandsInTown**, il n'y a pas de changement : comme les utilisateurs de Spotify, vous pourrez communiquer avec ces deux autres APIs en vous référant aux notes de cours et à l'énoncé du TP2. 