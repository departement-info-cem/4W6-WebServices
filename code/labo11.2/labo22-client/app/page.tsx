"use client";

import { createContext, useEffect, useState } from "react";
import { useReviewAPI } from "./_hooks/use-review-api"
import Post from "./_components/post";

export const UserContext = createContext<any>(null);

export default function Home() {

  const {
    // États
    reviews,
    // Requêtes
    register, login, 
    getReviews, postReview
  } = useReviewAPI();

  // Formulaire d'inscription
  const [regName, setRegName] = useState("");
  const [regPass, setRegPass] = useState("");
  const [regPassCon, setRegPassCon] = useState("");

  // Formulaire de connexion
  const [logName, setLogName] = useState("");
  const [logPass, setLogPass] = useState("");

  // Nouveau review
  const [newText, setNewText] = useState("");

  // Données identitaires
  const [username, setUsername] = useState("");
  const [roles, setRoles] = useState<string[]>([]);

  useEffect(() => {

    getReviews();

    // À compléter

  }, []);

  async function getLoginData() {

    // data contient toutes les données de connexion. (Ex : data.token)
    const data = await login(logName, logPass);



  }

  function logoff() {

    sessionStorage.removeItem("token");

  }

  return (
    <div>
      <div className="container">
        <div>

          {/* Profil */}
          <div className="profile">
            Profil actuel<br />
            <div className="smol">
              Pseudonyme : ???<br />
              Rôle(s) : ???
            </div>
          </div>

          {/* Inscription */}
          <div className="log">Inscription</div>
          <input type="text" placeholder="pseudo" value={regName} onChange={(e) => setRegName(e.target.value)} />
          <input type="text" placeholder="mot de passe" value={regPass} onChange={(e) => setRegPass(e.target.value)} />
          <input type="text" placeholder="confirmer le mot de passe" value={regPassCon} onChange={(e) => setRegPassCon(e.target.value)} />
          <button onClick={() => register(regName, regPass, regPassCon)}>S'inscrire</button>

          {/* Connexion */}
          <div className="log">Connexion</div>
          <input type="text" placeholder="pseudo" value={logName} onChange={(e) => setLogName(e.target.value)} />
          <input type="text" placeholder="mot de passe" value={logPass} onChange={(e) => setLogPass(e.target.value)} />
          <button onClick={getLoginData}>Se connecter</button>

          {/* Déconnexion */}
          <div className="log">Déconnexion</div>
          <button onClick={logoff}>Se déconnecter</button>

        </div>
        <div>

          <div className="title">Avis sur le cours Prog Web services</div>

          {/* Créer un nouveau post */}
          <div className="newPost">
            <textarea placeholder="Commentaires sur 4W6..." value={newText} onChange={(e) => setNewText(e.target.value)}></textarea>
            <button onClick={() => postReview(newText)}>Ajouter</button>
          </div>

          {/* Liste des posts */}
          <UserContext.Provider value={{ username, roles }}>
            {reviews.map(r =>
              <Post key={r.id} review={r} />
            )}
          </UserContext.Provider>
        </div>
      </div>
    </div>
  );
}
