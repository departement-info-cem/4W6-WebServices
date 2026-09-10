"use client";

import Link from "next/link";
import { useState } from "react";

export default function Home() {

  // Statistiques
  const [nbGames, setNbGames] = useState(0);
  const [quizHighScore, setQuizHighScore] = useState(0);
  const [survivalHighScore, setSurvivalHighScore] = useState(0);

  // Compte à rebours aléatoire (1 à 10) pour la bombe
  const [countdown, setCountdown] = useState(Math.floor(Math.random() * 10) + 1);

  // Cliquer réduit le compte à rebours de 1
  function bombClick(){
    setCountdown(Math.max(0, countdown - 1));
  }

  // Retourne un <div> avec une bombe ou une explosion selon le compte à rebours
  function getFidgetBomb(){
    return <div className="bomb" onClick={bombClick}>{countdown > 0 ? '💣' : '💥'}</div>
  }

  return (
    <div>
      {getFidgetBomb()}
      <div>Ce laboratoire utilise un projet ASP.Net Core exécuté localement pour proposer des questions quiz. Youpi !</div>
      <div className="options">
        <Link href="/play/5"><button>Quiz (5 questions)</button></Link>
        <Link href="/play/10"><button>Quiz (10 questions)</button></Link>
        <Link href="/play/survival"><button>Survie (max. 3 erreurs)</button></Link>
      </div>
      <hr/>
      <div className="score">Statistiques :</div>
      <div className="options">
        <div>Nombre de parties : {nbGames}</div>
        <div>Record (survie) : {survivalHighScore}</div>
        <div>Record (quiz) : {quizHighScore * 100}%</div>
      </div>
    </div>
  );
}
