export class Character{
    constructor(
        public name : string, 
        public age : number | null, 
        public powers : string[], 
        public imageUrl : string, 
        public isAlive : boolean
    ){}
}