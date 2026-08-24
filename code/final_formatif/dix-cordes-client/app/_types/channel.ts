import { Message } from "./message";

export class Channel{
    constructor(
        public id : number,
        public name : string,
        public messages : Message[]
    ){}
}