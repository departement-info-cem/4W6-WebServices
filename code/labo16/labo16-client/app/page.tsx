"use client";

import { useEffect, useState } from "react";
import { useDinoAPI } from "./_hooks/use-dino-api";

export default function Home() {

  useEffect(() => {

    getZookeepers();
    getDinosaurs();

  }, []);

  const {
    // États
    zookeepers, dinosaurs, incidentsOf, setIncidentsOf,
    // Requêtes GET
    getZookeepers, getDinosaurs,
    // Requêtes POST
    postZookeeper, postDinosaur, postIncident,
    // Requêtes DELETE
    deleteZookeeper, deleteDinosaur
  } = useDinoAPI();

  // Formulaire zookeeper
  const [keeperName, setKeeperName] = useState<string>("");

  // Formulaire dinosaure
  const [dinoName, setDinoName] = useState<string>("");
  const [dinoSpecie, setDinoSpecie] = useState<string>("");
  const [dinoKeeperId, setDinoKeeperId] = useState<number>(1);

  // Formulaire incident
  const [description, setDescription] = useState<string>("");
  const [nbVictims, setNbVictims] = useState<number>(0);
  const [selectedDinos, setSelectedDinos] = useState<number[]>([]);

  // Permet de sélectionner des dinosaures en vue de créer un incident
  async function selectDino(id: number) {

    if(!selectedDinos.includes(id)) setSelectedDinos([...selectedDinos, id]);
    else setSelectedDinos(selectedDinos.filter(s => s != id));

  }

  return (
    <div>
      <h3>Gardiens du zoo</h3>

      <input type="text" placeholder="Nom du gardien" value={keeperName} onChange={(e) => setKeeperName(e.target.value)} />
      <button onClick={() => postZookeeper(keeperName)}>Ajouter</button>

      <div className="display mb-2">
        {zookeepers.map(z =>
          <div key={z.id}>
            <p>Id : {z.id}</p>
            <p>Nom : {z.name}</p>
            <div className="delete" onClick={() => deleteZookeeper(z.id)}>❌</div>
          </div>
        )}
      </div>

      <hr />

      <h3>Dinosaures</h3>

      <input type="text" placeholder="Nom du dinosaure" value={dinoName} onChange={(e) => setDinoName(e.target.value)} />
      <input type="text" placeholder="Espèce" value={dinoSpecie} onChange={(e) => setDinoSpecie(e.target.value)} />
      <input type="number" placeholder="Id du gardien" value={dinoKeeperId} onChange={(e) => setDinoKeeperId(+e.target.value)} />
      <button onClick={() => postDinosaur(dinoName, dinoSpecie, dinoKeeperId)}>Ajouter</button>

      <div className="display mb-2">
        {dinosaurs.map(d =>
          <div key={d.id} className={selectedDinos.includes(d.id) ? 'light' : ''}>
            <p>Id : {d.id}</p>
            <p>Nom : {d.name}</p>
            <p>Espèce : {d.specie}</p>
            <p>Gardien : {d.zookeeper.name}</p>
            <button onClick={() => setIncidentsOf(d)}>Voir les incidents associés</button>
            <button className="ml-1" onClick={() => selectDino(d.id)}>Sélectionner</button>
            <div className="delete" onClick={() => deleteDinosaur(d.id)} >❌</div >
          </div >
        )}

      </div >

      <hr />

      <h3>Ajouter un incident</h3>

      <input type="text" placeholder="Description" value={description} onChange={(e) => setDescription(e.target.value)} />
      <input type="number" placeholder="Nombre de victime" value={nbVictims} onChange={(e) => setNbVictims(+e.target.value)} />
      <button onClick={() => postIncident(description, nbVictims, selectedDinos)}>Ajouter</button><br />
      N'oubliez pas de sélectionner tous les dinosaures impliqués ! <br />

      {incidentsOf &&
        <div className="mb-1">
          <hr />
          <div>
            <h3>Incidents impliquant le dinosaure {incidentsOf.name}</h3>

            <div className="display">
              {incidentsOf?.incidents.map(i =>
                <div key={i.id}>
                  <p>Id : {i.id}</p>
                  <p>Description : {i.description}</p>
                  <p>Victimes : {i.nbCasualties}</p>
                </div>
              )}
            </div>
          </div>
        </div>
      }

    </div >
  );
}