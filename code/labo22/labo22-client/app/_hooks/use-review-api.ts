import axios from "axios";
import { authRequest } from "../auth-interceptor";
import { useState } from "react";
import { Review } from "../_types/review";

const domain = "https://localhost:7033/api/";

export function useReviewAPI() {

    const [reviews, setReviews] = useState<Review[]>([]);

    async function register(username: string, password: string, passwordConfirm: string) {

        const registerDTO = {
            username: username,
            password: password,
            passwordConfirm: passwordConfirm
        };

        const x = await axios.post(domain + "Users/Register", registerDTO);
        console.log(x);

    }

    async function login(username: string, password: string) {

        const loginDTO = {
            username: username,
            password: password
        };

        const x = await axios.post(domain + "Users/Login", loginDTO);
        console.log(x.data);

        sessionStorage.setItem("token", x.data.token);

        return x.data;

    }

    async function getReviews() {

        const x = await authRequest.get(domain + "Reviews/GetReview");
        console.log(x.data);

        setReviews(x.data);

    }

    async function postReview(text: string) {

        const reviewDTO = { text: text };

        const x = await authRequest.post(domain + "Reviews/PostReview", reviewDTO);
        console.log(x.data);

        setReviews([...reviews, x.data]);

    }

    return {

        // États
        reviews,

        // Requêtes
        register, login, 
        getReviews, postReview

    };


}