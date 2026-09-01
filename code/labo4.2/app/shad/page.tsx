"use client";

import { useState } from "react";
import { Digimon } from "../_types/digimon";
import axios from "axios";

export default function Shad(){

    const digiImages : string[] = ["ditto", "gardevoir", "lopunny", "tsareena", "vaporeon"];
    const [digimon, setDigimon] = useState<Digimon | undefined>(undefined);
    const [digimonName, setDigimonName] = useState("");
    const [errorMessage, setErrorMessage] = useState("");

    async function searchDigimon(){

        try{
            const response = await axios.get("https://pokeapi.co/api/v2/pokemon/" + digimonName);
            console.log(response.data);

            let types : string[] = [];
            for(let t of response.data.types) types.push(t.type.name);

            setErrorMessage("");
            setDigimon(new Digimon(response.data.id, response.data.name, response.data.sprites.front_default, types));
        }
        catch(e){
            setDigimon(undefined);
            setErrorMessage("Ce pokémon n'existe pas.");
        }

    }

    return(
        <div className="p-4">
            <div className="text-xl mb-2 font-bold">Recherche de digimons</div>
            <div>Exemples de digimons : </div>
            <div className="carrousel">
                <img className="m-auto" src={'/images/' + digiImages[0] + '.png'} alt={digiImages[0]} />
                <div className="text-center">Nom : {digiImages[0]}</div>
            </div>
            <div className="mb-2 text-lg font-bold">Recherche</div>
            <input className="basicInput" type="text" placeholder="pikachu" value={digimonName} onChange={(e) => setDigimonName(e.target.value)} /> 
            <button className="ml-1 basicButton" onClick={searchDigimon}>Chercher</button>
            <div>{errorMessage}</div>
            {
                digimon &&
                <div>
                    <div className="mt-2 text-lg font-bold">Résultat</div>
                    <div>{digimon.id} - {digimon.name}</div>
                    <div>Type(s) : {digimon.types[0]} {digimon.types[1] != undefined && ' - ' + digimon.types[1]}</div>
                    <img src={digimon.imageUrl} alt={digimon.name} />
                </div>
            }
        </div>
    );

}