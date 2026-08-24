"use client";

import { useState } from "react";
import { useItemAPI } from "./_hooks/use-item-api"

export default function Home() {

  // États pour les input
  const [id, setId] = useState<number>(1);
  const [name, setName] = useState<string>("");
  const [value, setValue] = useState<number>(0);

  // Hook useItemAPI : accès aux requêtes et données
  const { singleItem, itemList, getAll, get, post, remove, put } = useItemAPI();

  return (
    <div>
      {/* GET ALL */}
      <div className="form">
        <div><button onClick={getAll} style={{ backgroundColor: '#61AFFE' }}>Voir tous mes items</button></div>
        <div>
          <table>
            <tbody>
              <tr>
                <td></td>
                <td><input type="text" disabled placeholder="Pèse juste sul'bouton dawg" /></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div>

      {/* GET ONE */}
      <div className="form">
        <div><button onClick={() => get(id)} style={{ backgroundColor: '#61AFFE' }}>Voir un item précis</button></div>
        <div>
          <table>
            <tbody>
              <tr>
                <td>Id : </td>
                <td><input type="number" placeholder="1" value={id} onChange={(e) => setId(+e.target.value)} /></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div >

      {/* POST */}
      <div className="form">
        <div><button onClick={() => post(name, value)} style={{ backgroundColor: '#49CC90' }}>Créer un item</button></div>
        <div>
          <table>
            <tbody>
              <tr>
                <td>Nom : </td>
                <td><input type="text" placeholder="skibidi" value={name} onChange={(e) => setName(e.target.value)} /></td>
                </tr>
              <tr>
                <td>Valeur : </td>
                <td><input type="number" placeholder="80" value={value} onChange={(e) => setValue(+e.target.value)} /></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div >

      {/* PUT */}
      <div className="form">
        <div><button onClick={() => put(id, name, value)} style={{ backgroundColor: '#FCA130' }}>Modifier un item</button></div>
        <div>
          <table>
            <tbody>
              <tr>
                <td>Id : </td>
                <td><input type="number" placeholder="1" value={id} onChange={(e) => setId(+e.target.value)} /></td>
              </tr>
              <tr>
                <td>Nom : </td>
                <td><input type="text" placeholder="gyat" value={name} onChange={(e) => setName(e.target.value)} /></td>
              </tr>
              <tr>
                <td>Valeur : </td>
                <td><input type="number" placeholder="2" value={value} onChange={(e) => setValue(+e.target.value)} /></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div >

      {/* DELETE */}
      <div className="form">
        <div><button onClick={() => remove(id)} style={{ background: 'linear-gradient(to right, #49CC90, #F54140)' }}>Supprimer un item</button></div>
        <div>
          <table>
            <tbody>
              <tr>
                <td>Id : </td>
                <td><input type="number" placeholder="1" value={id} onChange={(e) => setId(+e.target.value)} /></td>
              </tr>
            </tbody>
          </table>
        </div>
      </div >


      { /* Affichage d'un seul item */
        singleItem &&
        <div className="form">
          <div>Item précis :</div>
          <div>Id : {singleItem.id}, Nom : {singleItem.name}, Valeur : {singleItem.value}</div>
        </div>
      }

      { /* Affichage pour plusieurs items */
        itemList.length > 0 &&
        <div className="form">
          <div>Plusieurs items :</div>
          <div className="items">
            <table>
              <tbody>
                <tr>
                  <td>Id</td><td>Nom</td><td>Valeur</td>
                </tr>
                {itemList.map(i =>
                  <tr key={i.id}>
                    <td>{i.id}</td><td>{i.name}</td><td>{i.value}</td>
                  </tr>
                )}
              </tbody>
            </table>
          </div>
        </div>
      }
    </div >
  );
}
