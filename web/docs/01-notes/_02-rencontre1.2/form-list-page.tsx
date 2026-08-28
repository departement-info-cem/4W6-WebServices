'use client';

import { useState } from "react";
import { Item } from "./_types/item";

export default function Home() {

  const [name, setName] = useState<string>("");
  const [dateAdded, setDateAdded] = useState<string>("");
  const [quantity, setQuantity] = useState<number>(1);
  const [isBroken, setIsBroken] = useState<boolean>(false);

  const[items, setItems] = useState<Item[]>([]); // Tableau d'items vide

  function addItem(){
    setItems([
      ...items,
      new Item(name, new Date(dateAdded), quantity, isBroken)
    ]);
  }

  return (
    <div className="m-2">
      <div className="text-2xl">Items :</div>
      <ul className="list-disc ml-6 mb-5">
        {items.map((i) => <li key={i.name}>{i.quantity} x {i.name} (Obtenu le {i.dateAdded.toLocaleDateString()}) ({i.isBroken ? 'Brisé' : 'Intact'})</li>)}
      </ul>
      <div className="text-xl">Créer un item : </div>
      Nom : <input type="text" value={name} onChange={(e) => setName(e.target.value)} className="textInput" />
      Date d'ajout : <input type="date" value={dateAdded}  onChange={(e) => setDateAdded(e.target.value)} className="textInput" />
      Quantité : <input type="number" value={quantity}  onChange={(e) => setQuantity(+e.target.value)} className="textInput" />
      Brisé ? : <input type="checkbox" checked={isBroken}  onChange={(e) => setIsBroken(e.target.checked)} className="textInput" />
      <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold" onClick={addItem}>Ajouter</button>
    </div>
  );
}
