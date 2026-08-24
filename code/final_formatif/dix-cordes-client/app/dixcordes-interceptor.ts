import axios from "axios";

export const dixCordes = axios.create();

dixCordes.interceptors.request.use((config) => {

    config.headers.Authorization = "Bearer " + localStorage.getItem("token");

    return config;

});