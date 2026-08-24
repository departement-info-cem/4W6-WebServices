"use client";

import { useEffect, useState } from "react";
import { useWeebAPI } from "./_hooks/use-weeb-api";

export default function Home() {

  const {
    // États
    animes, myAnimes,
    // Requêtes
    getAnimes, getMyAnimes, postAnime, subscribe
  } = useWeebAPI();

  const [title, setTitle] = useState<string>("");
  const [genres, setGenres] = useState<string>("");
  const [imageUrl, setImageUrl] = useState<string>("");

  useEffect(() => {

    getAnimes();

    // ⛔ À décommenter lorsque vous compléterez getMyAnimes
    //if (sessionStorage.getItem("token")) getMyAnimes();

  }, []);

  function createAnime() {

    let genreArray = genres.split(",").map(e => e.trim());
    postAnime(title, genreArray, imageUrl == "" ? undefined : imageUrl);

  }

  return (
    <div>
      <h3>Ajouter un anime</h3>
      <input type="text" placeholder="Titre" value={title} onChange={(e) => setTitle(e.target.value)} />
      <input type="text" placeholder="Genres, séparés par des virgules" className="w-xs" value={genres} onChange={(e) => setGenres(e.target.value)} />
      <input type="text" placeholder="URL d'une image (optionnel)" className="w-2xs" value={imageUrl} onChange={(e) => setImageUrl(e.target.value)} />
      <button onClick={createAnime}>Ajouter</button>
      <hr />
      <h3>Tous les animes</h3>
      <div>Appuyez sur « Choisir » pour vous abonner / désabonner à un anime.</div>
      <div className="anime">
        {
          animes.map(a =>
            <div key={a.name}>
              <div>
                <button onClick={() => subscribe(a.id)}>Choisir</button>
                <img src={a.imageUrl ?? '/images/placeholder.png'} alt={a.name} />
              </div>
              <div className="self-start">
                <div className="font-bold text-lg mt-8">{a.name}</div>
                <div>Genre(s) :</div>
                <ul className="list-disc ml-4">
                  {a.genres.map(g => <li key={g}>{g}</li>)}
                </ul>
              </div>
            </div>
          )
        }
      </div>

      <hr />
      <h3>Vos animes</h3>
      {
        myAnimes.length == 0 && <div>Vous n'êtes abonné(e) à aucun anime pour le moment.</div>
      }
      <div className="anime2">
        {
          myAnimes.map(a =>
            <div key={a.name}>
              <div>
                <img src={a.imageUrl ?? '/images/placeholder.png'} alt={a.name} />
              </div>
              <div>
                <div className="font-bold text-lg">{a.name}</div>
                <div>Genre(s) :</div>
                <ul className="list-disc ml-4">
                  {a.genres.map(g => <li key={g}>{g}</li>)}
                </ul>
              </div>
            </div>
          )
        }
      </div>

    </div>
  );
}
