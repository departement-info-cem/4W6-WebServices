"use client";

import { GoogleMap, useJsApiLoader } from "@react-google-maps/api";
import { useState } from "react";

export default function Swift() {

    const [inputLat, setInputLat] = useState<number>(0);
    const [inputLng, setInputLng] = useState<number>(0);

    const center = { lat: 42, lng: -4 };
    const zoom = 2;

    const { isLoaded } = useJsApiLoader({
        id: "google-map-script",
        googleMapsApiKey: "🔑🔑🔑"
    })

    // Ajoutez un marqueur dans votre tableau de marqueurs en vous servant des données inputLat et inputLng !
    function addMarker() {

    }

    // Videz le tableau de marqueurs !
    function clearMarkers() {

    }

    return (
        <div className="row">
            <div className="description">
                <h3 className="text-xl font-bold">Placer des marqueurs 📍</h3>
                <p>
                    Taylor Swift peut utiliser son jet privé jusqu'à 13 fois par jour : aller chez le coiffeur, aller chez une amie, traverser la rue,
                    aller jusqu'à la piscine dans sa cour arrière, aller prendre un verre d'eau dans la cuisine, aller aux toilettes, etc.
                </p>
                <p>Aidez-la à planifier son itinéraire en rendant possible l'ajout de marqueurs dans cette carte Google.</p>
            </div>
            <div className="description">
                <h3 className="text-lg font-bold">Ajouter un marqueur</h3>
				Latitude : <input className="basicInput" type="number" name="lat" value={inputLat} onChange={(e) => setInputLat(+e.target.value)} step="1" />&nbsp;
				Longitude : <input className="basicInput" type="number" name="lng" value={inputLng} onChange={(e) => setInputLng(+e.target.value)} step="1" />
				<button className="basicButton" onClick={addMarker}>Ajouter ✈️</button>
				<button className="basicButton" onClick={clearMarkers}>Retirer tout 🚮</button>
            </div>
            {isLoaded &&
                <GoogleMap
                    center={center}
                    zoom={zoom}
                    mapContainerStyle={{ width: "700px", height: "400px", margin:"auto", marginBottom:"10px" }}
                >
                </GoogleMap>
            }
        </div>
    );

}