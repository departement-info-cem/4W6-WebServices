"use client";

import { useState } from "react";

export default function Home() {

  const characters : string[] = ["bebe","butters","clyde","craig","eric","kenny","kyle","nichole","stan","tolkien","wendy"];
  const [characterName, setCharacterName] = useState<string>("");

  return (
    <div>
      <h3>Accueil</h3>

      <h4>Option 1</h4>
      <p className="clic">Voir une liste de personnages<br/>
        { characters.map((c) => <img key={c} className="mini" src={'/images/' + c + '.png'} alt={c} />) }
      </p>

      <h4>Option 2</h4>
      <p>Chercher les détails d'un personnage</p>

      Nom : <input type="text" name="characterName" value={characterName} onChange={(e) => setCharacterName(e.target.value)} />
      <button className="clic">Chercher</button>


    </div>
  );
}
