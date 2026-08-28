'use client';

import { useState } from "react";
import { Npc } from "./_types/npc";

export default function Home() {

  const [npcs, setNpcs] = useState([
      new Npc("Ali", "Allo !", 19),
      new Npc("Bob", "Bonjour !", 23),
      new Npc("Camilo", "Ça va ?", 18)
  ])

  return (
    <div className="m-2">
        <div className="text-2xl">NPCs</div>
        <ul className="list-disc mx-4">
            {npcs.map(
              (n) => <li key={n.name}>{n.name} a {n.age} an(s) et dit « {n.quote} »</li>
            )}
        </ul>
    </div>
  );
}
