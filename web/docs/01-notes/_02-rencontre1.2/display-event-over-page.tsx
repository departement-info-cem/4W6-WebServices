'use client';

import { useState } from "react";

export default function Home() {

  const [textColor, setTextColor] = useState("blueText");

  function changeTextColor(color : string){
    setTextColor(color);
  }

  // Rendu HTML
  return (
    <div className="m-2">
      <div className={`${textColor} mb-1`}>Ce texte peut changer de couleur</div>
      <button className="btn btn-blue mr-2" onMouseOver={() => changeTextColor('blueText')}>Bleu</button>
      <button className="btn btn-red mr-2" onMouseOver={() => changeTextColor('redText')}>Rouge</button>
      <button className="btn btn-yellow" onMouseOver={() => changeTextColor('yellowText')}>Jaune</button>
    </div>
  );
}
