"use client";

import { useState } from "react";
import { Character } from "../_types/character";
import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";

export default function Home() {

  const [character, setCharacter] = useState<Character | null>();

  async function getCharacter(){

    // Personnage hardcodé si vous n'arrivez pas à compléter la fonction. NE SUPPRIMEZ PAS CETTE LIGNE DE CODE TROP VITE !
    setCharacter(new Character("Dupli-Kate", null, ["Réplication"], "http://localhost:5254/api/Characters/GetPicture/6", true));
    
  }

  function addToFavs() {

    if (!character) return;
    alert(character.name + " ajouté(e) aux favoris !");

    // À compléter

  }

  return (
    <div>
      <h2 className="text-xl my-2 font-bold">Recherche de personnages par nom</h2>

      <p className="mb-2">Exemples : Invincible, Atom Eve, Omni-Man, Allen the Alien, Dupli-Kate, etc.</p>

      <Input type="text" placeholder="Nom du personnage" className="w-xs mr-2 bg-white" />
      <Button variant="outline" className="cursor-pointer" onClick={getCharacter}>Rechercher</Button>

      {character &&
        <div>
          <h3 className="my-2 font-bold text-lg">Résultat</h3>
          <div className="row gap-2">
            <div>
              <img src={character.imageUrl} alt={character.name} />
            </div>
            <div>
              <p>Nom : {character.name}</p>
              <p>Âge : {character.age == null ? "Inconnu" : character.age}</p>
              <p>Statut : {character.isAlive ? 'En vie' : 'Vaincu(e)'}</p>
              <p className="my-1">Pouvoir(s) : </p>
              <ul>
                {character.powers.map(p => <li key={p}>{p}</li>)}
              </ul>
              <Button onClick={addToFavs} className="cursor-pointer mt-2">⭐ Ajouter aux favoris</Button>
            </div >
          </div>
        </div >
      }


    </div >
  );
}
