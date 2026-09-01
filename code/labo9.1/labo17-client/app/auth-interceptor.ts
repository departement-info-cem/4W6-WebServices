
import axios from "axios";

export const weebRequest = axios.create();

weebRequest.interceptors.request.use((config) => {



    return config;

});