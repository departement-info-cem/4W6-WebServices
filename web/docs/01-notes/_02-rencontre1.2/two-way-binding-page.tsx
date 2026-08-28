'use client';

import { useState } from "react";

export default function Home() {

  const [favoriteWord, setFavoriteWord] = useState("");

  return (
    <div className="m-2">
      <input value={favoriteWord} onChange={(e) => setFavoriteWord(e.target.value)} type="text" className="textInput" name="favoriteWord" placeholder="Mot préféré" />
      <div>{favoriteWord}</div>
    </div>
  );
}
