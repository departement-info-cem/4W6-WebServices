"use client";

import { useState } from "react";
import { Character } from "../../_types/character";
import { Button } from "@/components/ui/button";

export default function Favorites() {

    const [favorites, setFavorites] = useState<Character[]>([
		new Character("Atom Eve", 19, ["Manipulation de la matière"], "http://localhost:5254/api/Characters/GetPicture/2", true),
        new Character("Rex Splode", null, ["Charge cinétique"], "http://localhost:5254/api/Characters/GetPicture/7", false)
	]);

    function emptyFavs() {

    }

    return (
        <div>
            <h2 className="text-xl my-2 font-bold">Personnages favoris</h2>

            <div className="row gap-2 flex-wrap">
                {favorites.map((f,index) =>
                    <div key={index}>
                        <img src={f.imageUrl} alt={f.name} />
                        <p>Nom : {f.name}</p>
                        <hr className="my-1" />
                    </div>
                )}
            </div>

            <Button onClick={emptyFavs} className="cursor-pointer">Vider les favoris</Button>
        </div>
    );

}