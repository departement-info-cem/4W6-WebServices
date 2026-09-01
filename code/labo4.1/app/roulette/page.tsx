"use client";

import { useState } from "react";
import { RouletteGame } from "../_types/roulette-game";

export default function Roulette() {

    const [amount, setAmount] = useState(5);
    const [number, setNumber] = useState(0);
    const [roulette, setRoulette] = useState(new RouletteGame());

    function play(bet: any) {

        if (bet == undefined || !(bet == "red" || bet == "black" || (Number.isFinite(bet) && bet >= 0 && bet <= 36))) {
            alert("Hey arrête de niaiser 😠");
            return;
        }
        if (roulette.money < amount) {
            alert("🐖 Tirelire insuffisante ! 🐖");
            return;
        }
        roulette.startGame(bet, amount);

    }

    // █▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀█
    // █                      HTML                      █
    // █▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄▄█

    return (
        <div className="row rouletteRow">
            <div className="w-xs">
                <div className="form money text-center" id="rouletteMoney">💰 30 💰</div>
                <div className="form">
                    Montant misé : <input type="number" value={amount} onChange={(e) => setAmount(+e.target.value) } min="0" max="100" />
                </div>
                <form onSubmit={(e) => { e.preventDefault(); e.stopPropagation(); play(number) }}>
                    {amount}$ sur un numéro : <input type="number" name="number" value={number} onChange={(e) => setNumber(+e.target.value)} min="0" max="36" pattern="[0-9]+" />
                </form>
                <div className="form">
                    <button onClick={() => play('red')} className="btn-danger">{amount}$ sur rouge</button>&nbsp;
                    <button onClick={() => play('black')} className="btn-dark">{amount}$ sur noir</button>
                </div>
                <div className="form">
                    <button>Français</button>&nbsp;
                    <button>English</button>
                </div>
            </div>
            <div className="text-center">
                <h2 className="text-2xl font-bold mb-1">Roulette bilingue</h2>
                <div className="roulette">
                    <img src="/images/ball.png" alt="Ball" id="ball" style={{ left: '325px', top: '197px' }} />
                    <img src="/images/roulette.png" alt="Roulette" className="slot" />
                </div>
                <div id="messageRoulette">Ne pas jouer si vous êtes facilement étourdi(e)</div>
            </div>
        </div>
    );

}