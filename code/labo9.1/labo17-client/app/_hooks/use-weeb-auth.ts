import axios from "axios";

const domain = "https://localhost:7055/";

export function useWeebAuth(){

    async function register(user : string, mail : string, pass : string, passCon : string){

        const x = await axios.post(domain + "api/Users/Register", {
            username : user, 
            email : mail, 
            password : pass, 
            passwordConfirm : passCon
        });
        console.log(x.data);

    }

    async function login(user : string, pass : string){

        // À compléter

    }

    async function logout(){

        sessionStorage.removeItem("token");

    }

    return { register, login, logout };

}