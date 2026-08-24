"use client";

import { Input } from "@/components/ui/input";
import { Button } from "@/components/ui/button";
import { useTwoWayBinding } from "../../_hooks/use-two-way-binding";

export default function Superpowers() {

    const powerInput = useTwoWayBinding(""); // Hook pour le two-way binding

    return (
        <div>
            <h2 className="text-xl font-bold my-1">Recherche de personnages par pouvoir</h2>

            <p className="my-1">Exemples : Vol, Invulnérabilité, Régénération, Vitesse surhumaine, Force surhumaine, etc.</p>

            <Input type="text" {...powerInput} placeholder="Nom du personnage" className="bg-white w-xs" />
            <Button variant="outline" className="ml-1 cursor-pointer">Rechercher</Button>

            <p className="my-2">1 résultat(s)</p>

            <div className="row">
                <div>
                    <img src="http://localhost:5254/api/Characters/GetPicture/1" alt="Invincible" />
                    <p>Nom : Invincible</p>
                    <p>Âge : 19</p>
                    <p>Statut : En vie</p>
                    <hr className="my-1" />
                </div>
            </div>

        </div>
    );

}