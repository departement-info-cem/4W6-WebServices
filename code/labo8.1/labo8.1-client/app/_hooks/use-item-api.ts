import { useState } from "react";
import { Item } from "../_types/item";

const domain = "https://localhost:████";

export function useItemAPI(){

    // Données
    const [singleItem, setSingleItem] = useState<Item | null>(null);
    const [itemList, setItemList] = useState<Item[]>([]);

    // ▄▄▄▄▄▄▄▄▄▄▄▄
    //    GetAll
    // ▀▀▀▀▀▀▀▀▀▀▀▀
    async function getAll() : Promise<void>{



    }

    // ▄▄▄▄▄▄▄▄▄▄▄▄
    //      Get
    // ▀▀▀▀▀▀▀▀▀▀▀▀
    async function get(id : number) : Promise<void>{



    }

    // ▄▄▄▄▄▄▄▄▄▄▄▄
    //     Post
    // ▀▀▀▀▀▀▀▀▀▀▀▀
    async function post(name : string, value : number) : Promise<void>{



    }


    // ▄▄▄▄▄▄▄▄▄▄▄▄
    //    Delete
    // ▀▀▀▀▀▀▀▀▀▀▀▀
    // Note le mot-clé « delete » est réservé. La fonction se nomme remove() à la place.
    async function remove(id : number) : Promise<void>{



    }


    // ▄▄▄▄▄▄▄▄▄▄▄▄
    //     Put
    // ▀▀▀▀▀▀▀▀▀▀▀▀
    async function put(id : number, name : string, value : number) : Promise<void>{



    }
  
    return {singleItem, itemList, getAll, get, post, remove, put};

}