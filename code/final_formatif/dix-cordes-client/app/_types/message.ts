import { Reaction } from "./reaction";

export class Message{
    constructor(
        public id : number,
        public text : string,
        public sentAt : Date,
        public username : string,
        public reactions : Reaction[]
    ){}
}