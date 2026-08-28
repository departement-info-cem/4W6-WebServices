'use client';

import { useState } from "react";

export default function Home() {

  const [favoriteColor, setFavoriteColor] = useState("indigo"); // État
  const [daysWithoutWorkAccident, setDaysWithoutWorkAccident] = useState(0); // État

  return (
    <div className="m-2">
        <p>Salut. Tu aimes la couleur {favoriteColor}</p>
        <p>Il y a eu {daysWithoutWorkAccident} jour(s) sans accident au travail.</p>
    </div>
  );
}
