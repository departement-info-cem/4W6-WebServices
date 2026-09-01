import axios from "axios";
import { useState } from "react";

const domain = "https://localhost:7180/";

export function usePictureAPI() {

    const [pictureIds, setPictureIds] = useState<number[]>([]);

    async function postPicture(formData: any) {

        let x = await axios.post(domain + "api/Pictures/PostPicture", formData);
        console.log(x.data);

    }

    async function getPictureIds() {

        let x = await axios.get(domain + "api/Pictures/GetPictureIds");
        console.log(x.data);

        setPictureIds(x.data);

    }

    async function deletePicture(id: number) {

        let x = await axios.delete(domain + "api/Pictures/DeletePicture/" + id);
        console.log(x.data);

        getPictureIds();

    }

    return {

        // États
        pictureIds,

        // Requêtes
        postPicture, getPictureIds, deletePicture

    };

}