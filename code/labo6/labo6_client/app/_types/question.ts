
export class Question{

    constructor(
        public text : string,
        public correct : number,
        public answers : string[],
        public selected : number
    ){}

}