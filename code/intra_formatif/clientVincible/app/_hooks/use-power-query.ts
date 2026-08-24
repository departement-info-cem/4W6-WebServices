import axios from "axios";
import { Character } from "../_types/character";
import { useState } from "react";

export function usePowerQuery(){

    const [characters, setCharacters] = useState<Character[]>([]);

    async function getCharacters(power : string){

        let response = await axios.get("http://localhost:5254/api/Characters/GetCharactersByPower/" + power);
        console.log(response.data);

        let newCharacters = [];
        
        for(let c of response.data){
            newCharacters.push(new Character(c.name, c.age, c.superpowers, c.imageUrl, c.isAlive))
        }

        setCharacters(newCharacters);

    }

    return { characters, getCharacters }; 

}