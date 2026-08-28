'use client';

import { useState } from "react";

export default function Home() {

  // Âge de l'utilisateur
  const [userAge, setUserAge] = useState(18);

  return (
    <div className="m-2">
      {
        userAge >= 18 && <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold mr-2">Acheter des cigarettes 🚬</button>
      }
      <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold">Acheter des briques 🧱</button>
    </div>
  );
}
