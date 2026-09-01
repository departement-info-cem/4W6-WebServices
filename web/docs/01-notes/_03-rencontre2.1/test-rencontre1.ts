import type { QuizData } from "@site/src/components/Quiz/quizEngine";
import question1Texte from "!!raw-loader!./question1.md";
import question2Texte from "!!raw-loader!./question2.md";
import question3Texte from "!!raw-loader!./question3.md";

const quiz: QuizData = {
    titre: "Quiz test - Rencontre 1.1",
    questions: [
        {
            texte: question1Texte,
            choix: ["0 puis 0", "Impossible à prévoir", "10 puis 20", "0 puis 10"],
            reponse: 3,
            duree: 90,
        },
        {
            texte: question2Texte,
            choix: ["Impossible de le savoir", "Oui, Kiwi sera ajouté au début de la liste.", "Oui, Kiwi sera ajouté à la fin de la liste.", "Non"],
            reponse: 3,
            duree: 90,
        },
        {
            texte: question3Texte,
            choix: ["C'est une erreur de syntaxe (un mot clé est mal formulé)", "Il n'y a pas d'erreur (C'était un piège!)", "On doit utiliser une fonction anonyme (lambda)", ""],
            reponse: 0,
            duree: 90,
        },
    ],
};

export default quiz;
