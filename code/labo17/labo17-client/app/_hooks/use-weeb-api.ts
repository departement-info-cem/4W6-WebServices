import { useState } from "react";
import { Anime } from "../_types/anime";
import axios from "axios";
import { weebRequest } from "../auth-interceptor";

const domain = "https://localhost:7055/";

export function useWeebAPI(){

    const [animes, setAnimes] = useState<Anime[]>([]);
    const [myAnimes, setMyAnimes] = useState<Anime[]>([]);

    async function getAnimes(){

        const x = await axios.get(domain + "api/Animes/GetAnime");
        console.log(x.data);

        setAnimes(x.data);

    }

    async function getMyAnimes(){

        const x = await weebRequest.get(domain + "api/Animes/GetMyAnimes");
        console.log(x.data);

        setMyAnimes(x.data);


    }

    async function postAnime(name : string, genres : string[], imageUrl ?: string){

        const anime = new Anime(0, name, genres, imageUrl );
        const x = await weebRequest.post(domain + "api/Animes/PostAnime", anime);
        console.log(x.data);

        setAnimes([...animes, x.data]);
        // ⛔ À décommenter lorsque vous compléterez getMyAnimes
        //getMyAnimes();

    }

    async function subscribe(id : number){

        const x = await weebRequest.put(domain + "api/Animes/SubscribeAnime/" + id);
        console.log(x.data);

        getMyAnimes();

    }

    return {

        // États
        animes, myAnimes,

        // Requêtes
        getAnimes, getMyAnimes, postAnime, subscribe

    };

}