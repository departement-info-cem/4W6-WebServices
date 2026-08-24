import { useState } from "react";

export function useBinding(startValue : string){

    const [value, setValue] = useState<string>(startValue);

    return { value : value, onChange : (e : any) => setValue(e.target.value) };

}