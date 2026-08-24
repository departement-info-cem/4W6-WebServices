import { apiDomain } from "@/next.config";
import { dixCordes } from "../dixcordes-interceptor";

export function useAccount(){

    async function login(name : string, pass : string){

        const x = await dixCordes.post(apiDomain + "/api/Users/Login", {
            username : name,
            password : pass
        });
        console.log(x.data);

        localStorage.setItem("token", x.data.token);

    }

    async function register(name : string, pass : string, passCon : string){

        const x = await dixCordes.post(apiDomain + "/api/Users/Register", {
            username : name,
            password : pass,
            passwordConfirm : passCon
        });

        console.log(x.data);

    }

    async function logout(){

        localStorage.removeItem("token");

    }

    return { register, login, logout };

}