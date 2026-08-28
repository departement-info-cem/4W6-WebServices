'use client';

import { useState } from "react";

export default function Home() {

  const [x, setX] = useState(0);

  function incrementX(){
    setX(x + 1);
  }

  return (
    <div className="m-2">
      <div>{x}</div>
      <button className="bg-blue-500 text-white py-2 px-4 rounded-sm font-bold" onClick={incrementX}>Incrémenter X</button>
    </div>
  );
}
