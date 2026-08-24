"use client";

import axios from "axios";
import { useState } from "react";
import { Artist } from "../_types/artist";

const CLIENT_ID: string = "";
const CLIENT_SECRET: string = "";

// ███ ^↑^ VOS IDENTIFIANTS SPOTIFY ^↑^ ███

export default function Spotify() {

    const [artistName, setArtistName] = useState<string>("");
    const [artist, setArtist] = useState<any>();
    const [spotifyToken, setSpotifyToken] = useState<string>("");

    async function connect() {

        // Attention ! Pour une fois, on utilise une requête POST
        const response = await axios.post("https://accounts.spotify.com/api/token",
            // On joint un contenu (body) à la requête
            new URLSearchParams({ grant_type: "client_credentials" }), {
            // On joint des en-têtes (headers) à la requête
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                "Authorization": "Basic " + btoa(CLIENT_ID + ":" + CLIENT_SECRET)
            }
        });
        console.log(response.data);

        // response.data.access_token contient le token qu'on voulait obtenir !
        setSpotifyToken(response.data.access_token);

    }

    async function getArtist() {

        const response = await axios.get('https://api.spotify.com/v1/search?type=artist&offset=0&limit=1&q=' + artistName, {
            // On joint le token dans les en-têtes de la requête !
            headers: {
                "Content-Type": "application/x-www-form-urlencoded",
                "Authorization": "Bearer " + spotifyToken
            }
        });
        console.log(response.data);

        // On joint le token dans les en-têtes de la requête !
        setArtist(new Artist(response.data.artists.items[0].id, response.data.artists.items[0].name, response.data.artists.items[0].images[0].url));

    }

    return (
        <div className="row justify-content-around">
            {spotifyToken != "" &&
                <div>
                    <div className="ml-4">
                        <h3 className="text-2xl font-bold">Chercher un artiste</h3>
                        <input value={artistName} onChange={(e) => setArtistName(e.target.value)} type="text" name="artistName" placeholder="Nana Mouskouri" />
                        <button onClick={getArtist} className="btn-light ml-2 py-0">Rechercher</button>
                    </div>
                    {artist != undefined &&
                        <div className="ml-4">
                            <h3 className="text-xl font-bold">Résultat</h3>
                            <p>Nom : {artist.name}</p>
                            <img width="400" src={artist.imageUrl} alt={artist.name} />
                        </div>
                    }
                </div>
            }
        </div>
    );

}