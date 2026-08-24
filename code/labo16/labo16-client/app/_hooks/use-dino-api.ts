import axios from "axios";
import { Zookeeper } from "../_types/zookeeper";
import { Dinosaur } from "../_types/dinosaur";
import { useState } from "react";
import { Incident } from "../_types/incident";

const domain = "https://localhost:7298/";

export function useDinoAPI() {

    // États pour affichage
    const [zookeepers, setZookeepers] = useState<Zookeeper[]>([]);
    const [dinosaurs, setDinosaurs] = useState<Dinosaur[]>([]);
    const [incidentsOf, setIncidentsOf] = useState<Dinosaur | null>(null);

    async function getZookeepers() {

        let x = await axios.get(domain + "api/Zookeepers/GetZookeeper");
        console.log(x.data);

        setZookeepers(x.data);

    }

    async function getDinosaurs() {

        let x = await axios.get(domain + "api/Dinosaurs/GetDinosaur");
        console.log(x.data);
        
        setDinosaurs(x.data);

    }

    async function postZookeeper(name: string) {

        const x = await axios.post(domain + "api/Zookeepers/PostZookeeper", new Zookeeper(0, name));
        console.log(x.data);

        // Ajouter immédiatement le nouveau zookeeper pour l'affichage
        setZookeepers([...zookeepers, x.data]);

    }

    async function postDinosaur(name: string, specie: string, id: number) {

        // À compléter

        // À modifier
        setDinosaurs([...dinosaurs, new Dinosaur(0, "Betty", "caniche", [], new Zookeeper(0, "Cassandra"))]);

    }

    async function postIncident(description: string, nbCasualties: number, ids: number[]) {

        // À compléter

        // Mise à jour de la page (Cette partie du code n'a aucun impact sur la BD, c'est juste visuel !) : 
        // Ajouter le nouvel incident dans les dinosaures associés + modifier la liste des incidents affichés au besoin
        let dinos = [...dinosaurs];
        for(let d of dinos){
            if(ids.includes(d.id)){
                d.incidents.push(new Incident(0, 0, new Date(), "")); // Remplacez cet incident par le nouveau
            }
        }
        setDinosaurs(dinos);

        if(incidentsOf && ids.includes(incidentsOf.id)){
            setIncidentsOf(dinos.find(d => d.id == incidentsOf.id)!);
        }

    }

    async function deleteDinosaur(id: number) {

        // À compléter

        // Mise à jour de la page (Cette partie du code n'a aucun impact sur la BD, c'est juste visuel !) : 
        // Retrait du dinosaur + retrait des incidents si dinosaure sélectionné
        setDinosaurs(dinosaurs.filter(d => d.id != id));
        if(incidentsOf && incidentsOf.id == id) setIncidentsOf(null);

    }

    async function deleteZookeeper(id: number) {

        // À compléter

        // Mise à jour de la page (Cette partie du code n'a aucun impact sur la BD, c'est juste visuel !) :  
        // Retrait du zookeeper + retrait de ses dinosaurs + retrait des incidents si dinosaure sélectionné est supprimé
        setZookeepers(zookeepers.filter(z => z.id != id));
        setDinosaurs(dinosaurs.filter(d => d.zookeeper.id != id));
        if(incidentsOf && incidentsOf.zookeeper.id == id) setIncidentsOf(null);

    }

    return {
        // États
        zookeepers, dinosaurs, incidentsOf, setIncidentsOf,

        // Requêtes GET
        getZookeepers, getDinosaurs, 

        // Requêtes POST
        postZookeeper, postDinosaur, postIncident, 

        // Requêtes DELETE
        deleteZookeeper, deleteDinosaur
    };

}