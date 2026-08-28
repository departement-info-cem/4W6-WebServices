'use client';

import { useState } from "react";

export default function Home() {

  // Âge de l'utilisateur
  const [userAge, setUserAge] = useState(18);

  function displayButtons(){

    // Boutons pour les 18+
    if(userAge >= 18){
      return <div>
        <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold mr-2">Acheter des cigarettes 🚬</button>
        <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold">Acheter des briques 🧱</button>
      </div>;
    }
    // Boutons pour les 17-
    else{
      return <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold">Acheter des briques 🧱</button>;
    }
  }

  // Rendu HTML
  return (
    <div className="m-2">
      {displayButtons()}
    </div>
  );
}
