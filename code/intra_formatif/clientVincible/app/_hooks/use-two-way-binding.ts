import { useState } from "react";

export function useTwoWayBinding(startValue : any){

    const [inputValue, setInputValue] = useState(startValue);

    return {value : inputValue, onChange : (e : any) => setInputValue(e.target.value)};

}