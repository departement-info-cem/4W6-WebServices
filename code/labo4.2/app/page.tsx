"use client";

import { useState } from "react";

// CLÉ D'API 🔑
const googleApiKey = "";

export default function Home() {

  const [searchInput, setSearchInput] = useState("");
  const [videoUrl, setVideoUrl] = useState<string | undefined>(undefined);

  function searchVideo() {

  }

  return (
    <div className="row">
      <div className="search">
        <h3>Chercher une vidéo 🎥</h3>
        <form onSubmit={(e) => { e.preventDefault(); e.stopPropagation(); searchVideo(); }}>
          <input className="basicInput" type="text" name="videoSearchText" placeholder="ASMR tongue sounds" value={searchInput} onChange={(e) => setSearchInput(e.target.value)} />
          <button className="basicButton" type="submit">Rechercher</button>
        </form>

      </div>
      {
        videoUrl != undefined &&
        <div className="videoPlayer">

          <iframe width="560" height="315" src={videoUrl} title="YouTube video player"
            allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture; web-share"
            referrerPolicy="strict-origin-when-cross-origin" allowFullScreen></iframe>

        </div>
      }

    </div>
  );
}
