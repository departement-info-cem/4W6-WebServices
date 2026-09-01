"use client";

import { useEffect, useRef } from "react";
import { usePictureAPI } from "./_hooks/use-picture-api";

export default function Home() {

  const {
    // État
    pictureIds,
    // Requêtes
    postPicture, getPictureIds, deletePicture
  } = usePictureAPI();

  useEffect(() => {

    // Appeler la bonne fonction pour remplir l'état pictureIds dans le hook usePictureAPI.

  }, []);

  function prepareFormData() {

    // À compléter

    // postPicture(formData);

  }

  return (
    <div>
      <h3>Laboratoire 21</h3>

      <input type="file" accept="images/*" />
      <button onClick={prepareFormData}>Ajouter l'image</button><br /><br />
      <button onClick={getPictureIds}>Mettre à jour les images affichées</button>

      <br /><br />

      {/* Affichage des images */}
      {
        pictureIds.map(i =>
          <div className="picture" key={i}>
            <div className="delete">X</div>
            <a href="" target="blank">
              <img src="/images/placeholder.png" alt="Picture" />
            </a>
          </div>
        )
      }

    </div>

  );
}
