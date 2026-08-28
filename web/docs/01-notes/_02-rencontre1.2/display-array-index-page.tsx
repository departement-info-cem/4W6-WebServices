'use client';

import { useState } from "react";

export default function Home() {

  const [ages, setAges] = useState([17, 18, 17, 19, 20, 18]); // Certaines valeurs se répètent ...

  return (
    <div className="m-2">
        <div className="text-2xl">Âges</div>
        <ul className="list-disc mx-4">
            {ages.map(
                (i, index) => <li key={index}>{index} - {i}</li>
                // i contient chaque donnée.
                // index contient chaque ... index ! (0, 1, 2, etc.)
            )}
        </ul>
    </div>
  );
}
