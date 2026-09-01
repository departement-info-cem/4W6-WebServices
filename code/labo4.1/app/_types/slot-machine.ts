import { Profile } from "./profile";

export class SlotMachine {

    imgCol = [["cerise", "arcenciel", "bague", "huit", "melon", "foudre"], 
    ["arcenciel", "cerise", "huit", "bague", "foudre", "melon"], 
    ["bague", "cerise", "melon", "foudre", "huit", "arcenciel"]];
    index = [0, 0, 0];
    // Le jeu est-il lancé ?
    jeuActif = false;

    // Variables pour stocker les planificateurs des 3 colonnes
    planificateurColonne: any[] = [];

    // Quelles colonnes sont en train de bouger ?
    colActive = [false, false, false];

    init() {
        this.afficherIcones();
    }

    stop(i: number) {
        if (this.colActive[i]) {
            clearInterval(this.planificateurColonne[i]);
            document.getElementById("stop" + (i + 1))!.style.display = "none";
            this.colActive[i] = false;
        }
    }

    changerColonne(i: number) {
        this.index[i] = (this.index[i] + 1) % this.imgCol[i].length;
        this.afficherColonne(this.index[i], this.imgCol[i], i + 1);
    }

    afficherIcones() {
        this.afficherColonne(this.index[0], this.imgCol[0], 1);
        this.afficherColonne(this.index[1], this.imgCol[1], 2);
        this.afficherColonne(this.index[2], this.imgCol[2], 3);
    }

    afficherColonne(index: number, tableau: any, col: number) {
        for (let i = 1; i < 6; i++) {
            let numImage = (index + (i - 3)) % tableau.length;
            numImage = numImage < 0 ? numImage + tableau.length : numImage;
            document.getElementById("col" + col + "row" + i)!.setAttribute("src", "/images/" + tableau[numImage] + ".png")
        }
    }

    activerJeu() {
        this.planificateurColonne[0] = setInterval(this.changerColonne.bind(this), 200, 0);
        this.planificateurColonne[1] = setInterval(this.changerColonne.bind(this), 200, 1);
        this.planificateurColonne[2] = setInterval(this.changerColonne.bind(this), 200, 2);
        for (let index = 1; index < 4; index++) {
            document.getElementById("stop" + index)!.style.display = "block";
        }
        this.colActive[0] = true;
        this.colActive[1] = true;
        this.colActive[2] = true;
        console.log(this.colActive);
        document.getElementById("message")!.textContent = "C'est parti !";
        this.jeuActif = true;
    }

    finJeu(): boolean {
        if (!this.colActive[0] && !this.colActive[1] && !this.colActive[2]) {
            this.jeuActif = false;
            if (this.imgCol[0][this.index[0]] == this.imgCol[1][this.index[1]] && this.imgCol[0][this.index[0]] == this.imgCol[2][this.index[2]]) {
                //this.profile!.money += 5;
                document.getElementById("message")!.textContent = "Bien joué ! +5$ ";
                return true;
            }
            else {
                document.getElementById("message")!.textContent = "Aïe. Meilleure chance la prochaine fois.";
                return false;
            }
        }
        return false;
    }

}