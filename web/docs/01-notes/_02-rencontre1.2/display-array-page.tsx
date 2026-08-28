'use client';

import { useState } from "react";

export default function Home() {

  const [ingredients, setIngredients] = useState(["patate", "huile d'olive", "sel"]);

  return (
    <div className="m-2">
        <div className="text-2xl">Ingrédients</div>
        <ul className="list-disc mx-4">
            {ingredients.map(
                (i) => <li key={i}>{i}</li>
            )}
        </ul>
    </div>
  );
}
