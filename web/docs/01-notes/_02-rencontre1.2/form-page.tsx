'use client';

import { useState } from "react";

export default function Home() {

  const [name, setName] = useState<string>("");
  const [dateAdded, setDateAdded] = useState<string>("");
  const [quantity, setQuantity] = useState<number>(1);
  const [isBroken, setIsBroken] = useState<boolean>(false);

  return (
    <div className="m-2">
      Nom : <input type="text" value={name} onChange={(e) => setName(e.target.value)} className="textInput" />
      Date d'ajout : <input type="date" value={dateAdded}  onChange={(e) => setDateAdded(e.target.value)} className="textInput" />
      Quantité : <input type="number" value={quantity}  onChange={(e) => setQuantity(+e.target.value)} className="textInput" />
      Brisé ? : <input type="checkbox" checked={isBroken}  onChange={(e) => setIsBroken(e.target.checked)} className="textInput" />
    </div>
  );
}
