"use client";

import { useContext, useEffect, useState } from "react";
import { Review } from "../_types/review";
import { UserContext } from "../page";
import { authRequest } from "../auth-interceptor";

const domain = "https://localhost:7033/api/";

export default function Post(props: { review: Review }) {

    const { username, roles } = useContext(UserContext);
    const [review, setReview] = useState<Review | null>(null);

    useEffect(() => {

        setReview(props.review);

    }, []);

    async function deleteReview() {

        const x = await authRequest.delete(domain + "Reviews/DeleteReview/" + review?.id);
        console.log(x.data);

        setReview(new Review(-1, "Avis supprimé", "Anonyme"));

    }

    return (

        <div>
            {
                review != null &&
                <div className="post">
                    <div className="delete" onClick={deleteReview}>❌</div>
                    <div className="text">{review.text}</div>
                    <div className="signature">- {review.author}</div>
                </div>
            }
        </div>



    );

}