'use client';

import { useState } from "react";

export default function Home() {

  // Âge de l'utilisateur
  const [userAge, setUserAge] = useState(18);

  return (
    <div className="m-2">
      <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold">
        {
          userAge >= 18 ? <span>Acheter des cigarettes 🚬</span> : <span>Acheter des briques 🧱</span>
        }
      </button>
    </div>
  );
}
