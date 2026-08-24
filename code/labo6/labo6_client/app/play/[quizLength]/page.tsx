"use client";

import { Question } from "@/app/_types/question";
import axios from "axios";
import { useParams } from "next/navigation";
import { useEffect, useState } from "react";

export default function Play(){

    // Paramètre de route
    const params = useParams<{ quizLength : string }>();

    // Statistiques
    const [nbGames, setNbGames] = useState(0);
    const [quizHighScore, setQuizHighScore] = useState(0);

    // Compte à rebours aléatoire (1 à 10) pour la bombe
    const [countdown, setCountdown] = useState(Math.floor(Math.random() * 10) + 1);

    // États pour le jeu
    const [questions, setQuestions] = useState<Question[]>([]);
    const [score, setScore] = useState<number>(-1);

    // Vérifier le nombre de questions avec le paramètre de route et obtenir les questions
    useEffect(() => {

        const length = +params.quizLength;
        fillQuestions(length);

    }, []);

    // Cliquer réduit le compte à rebours de 1
    function bombClick(){
        setCountdown(Math.max(0, countdown - 1));
    }

    // Retourne un <div> avec une bombe ou une explosion selon le compte à rebours
    function getFidgetBomb(){
        return <div className="bomb" onClick={bombClick}>{countdown > 0 ? '💣' : '💥'}</div>
    }

    // Remplir la liste de questions
    async function fillQuestions(length : number){

        setQuestions(await getQuestions(length));

    }

    // Retourne la classe appropriée pour les choix de réponses (vert, rouge ou rien)
    function getAnswerClass(question : Question, index : number){

        if(question.selected < 0) return "";
        if(question.correct == index) return "right";
        if(question.selected == index && question.correct != index) return "wrong";
        return "";

    }

    // Gérer le choix d'une réponse, potentiellement valide ou erroné
    function chooseAnswer(question : Question, answer : string){
        if(question.selected >= 0) return;
        let updatedQuestions = [...questions];
        let quizDone = true;
        let currentScore = 0;
        for(let q of updatedQuestions){
            if(q.text == question.text){
                q.selected = q.answers.indexOf(answer);
            }
            if(q.selected == -1) quizDone = false;
            if(q.selected == q.correct) currentScore += 1;
        }
        setQuestions(updatedQuestions);

        // Fin partie ?
        if(quizDone){

            setScore(currentScore);

            // Nouveau record ?
            setQuizHighScore(Math.max(currentScore / questions.length, quizHighScore));

            // +1 partie jouée
            setNbGames(nbGames + 1);
        }
    }

    // Requête pour obtenir les questions
    async function getQuestions(length : number){

        if(isNaN(length) || length <= 0) length = 5; // Longueur invalide ? Utilisons 5

        const response = await axios.get(`http://localhost:5064/api/questions/getquestions/${length}`);
        console.log(response.data);

        let q : Question[] = [];

        for(let r of response.data){
            q.push(new Question(r.text, r.correct, r.answers, -1));
        }

        return q;

    }

    return(
        <div>
            {getFidgetBomb()}
            <div className="options">
                <div>Nombre de parties : {nbGames}</div>
                <div>Record (quiz) : {quizHighScore * 100}%</div>
            </div>
            <h3>Quiz ({params.quizLength} questions)</h3>
            <div>
                {questions.map((q, index) => 
                <div key={index} className="question">
                    <div>{q.text}</div>
                    <div className="answers">
                        {q.answers.map((a, index) => 
                        <div key={index} onClick={() => chooseAnswer(q, a)} className={getAnswerClass(q, index)}>{a}</div>
                        )}
                    </div>
                </div>
                )}
                { score >= 0 &&
                  <div className="result">Votre score est de {score} / {questions.length} ({score/questions.length * 100} %)</div> 
                }
            </div>
        </div>
    );

}