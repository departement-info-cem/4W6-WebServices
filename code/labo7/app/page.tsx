"use client";

import { useState } from "react"
import { Profile } from "./_types/profile";
import { SlotMachine } from "./_types/slot-machine";

export default function Home() {

  const [slotMachine, setSlotMachine] = useState(new SlotMachine());

  const [profile, setProfile] = useState<any>(undefined);
  const [name, setName] = useState<string>("");
  const [age, setAge] = useState<string>("");

  function createProfile(): void {
    setProfile(new Profile(name, age, 20)); // Le profil est créé
  }

  function clearProfile(): void {
    setProfile(undefined); // Le profil est supprimé
  }

  function jouer() {
    if (profile == undefined || profile.money < 1 || (slotMachine != undefined) && slotMachine.jeuActif) {
      alert("Impossible de lancer le jeu.")
    }
    else {
      setProfile({ ...profile, money: profile.money - 1 }); // Le montant d'argent change !
      slotMachine.activerJeu();
    }
  }

  function finJeu() {
    if (slotMachine && slotMachine.finJeu()) {
      setProfile({ ...profile, money: profile.money + 5 }); // Le montant d'argent change !
    }
  }

  function stop(i: number) {
    slotMachine.stop(i);
    finJeu();
  }


  // █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█
  // █                      HTML                      █
  // █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█

  return (
    <div>
      <div className="row slotMachine">
        <div className="form">
          {!profile &&
            <div>
              Nom
              <input type="text" name="name" value={name} onChange={(e) => setName(e.target.value)} placeholder="Maurice" /><br />
              Âge
              <input type="number" name="age" value={age} onChange={(e) => setAge(e.target.value)} placeholder="56" /><br />
              <button onClick={createProfile}>Créer le profil</button>
            </div>
          }
          {profile &&
            <div className="form text-center">
              <img src="/images/profile.png" alt="Profil" className="profile" width="150" />
              <div>Nom : {profile.name}</div>
              <div>Âge : {profile.age} ans</div>
              <div>Argent : {profile.money} $</div><br />
              <button onClick={clearProfile}>Nouveau profil</button>
            </div>
          }

        </div>
        <div className="text-center">
          <div className="rowJeu">
            <div className="jeu">
              <img src="/images/ici.png" alt="Indicateur" id="fleche" />
              <div className="rowJeu">
                <div className="colJeu">
                  <img id="col1row1" src="/images/cerise.png" alt="Icône" className="petit" />
                  <img id="col1row2" src="/images/arcenciel.png" alt="Icône" className="moyen" />
                  <img id="col1row3" src="/images/bague.png" alt="Icône" className="grand" />
                  <img id="col1row4" src="/images/huit.png" alt="Icône" className="moyen" />
                  <img id="col1row5" src="/images/melon.png" alt="Icône" className="petit" />
                </div>
                <div className="colJeu">
                  <img id="col2row1" src="/images/arcenciel.png" alt="Icône" className="petit" />
                  <img id="col2row2" src="/images/cerise.png" alt="Icône" className="moyen" />
                  <img id="col2row3" src="/images/huit.png" alt="Icône" className="grand" />
                  <img id="col2row4" src="/images/bague.png" alt="Icône" className="moyen" />
                  <img id="col2row5" src="/images/foudre.png" alt="Icône" className="petit" />
                </div>
                <div className="colJeu">
                  <img id="col3row1" src="/images/bague.png" alt="Icône" className="petit" />
                  <img id="col3row2" src="/images/cerise.png" alt="Icône" className="moyen" />
                  <img id="col3row3" src="/images/melon.png" alt="Icône" className="grand" />
                  <img id="col3row4" src="/images/foudre.png" alt="Icône" className="moyen" />
                  <img id="col3row5" src="/images/huit.png" alt="Icône" className="petit" />
                </div>
              </div>
              <div className="rowJeu stopRow">
                <div className="colStop">
                  <div id="stop1" onMouseDown={() => stop(0)}>Stop</div>
                </div>
                <div className="colStop">
                  <div id="stop2" onMouseDown={() => stop(1)}>Stop</div>
                </div>
                <div className="colStop">
                  <div id="stop3" onMouseDown={() => stop(2)}>Stop</div>
                </div>
              </div>
            </div>

            <div className="panneau">
              <div className="rowJeu">
                <div id="jouer" onClick={jouer}>Jouer (-1$)</div>
              </div>
              <div className="rowJeu">
                <div id="message">Qu'attendez-vous pour jouer ?</div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
