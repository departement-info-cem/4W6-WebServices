'use client';

import { useState } from "react";
import { Youtuber } from "./_types/youtuber";

export default function Home() {

  const [youtubers, setYoutubers] = useState([
    new Youtuber("MotherSniperZz", "Call of Duty gaming", 16),
    new Youtuber("Ka$haStudioASMR", "ASMR", 24),
    new Youtuber("SussyBaka69", "NSFW", null),
    new Youtuber("Bl0ck4L1f3", "LEGO Collection", 47)
  ]);

  // Ajouter l'émoji 😳 si le contenu est suspect
  function isSussy(content : string){
    if(content == "ASMR" || content == "NSFW"){
      return <span>😳</span>;
    }
    else{
      return "";
    }
  }

  // Rendu HTML
  return (
    <div className="m-2">
      <div className="text-2xl">Youtubeurs</div>
      <ul className="list-disc ml-4">
        {youtubers.map((y) =>
          <li key={y.name}>{y.name} ({y.age ?? '???'} ans) fait des vidéos sur le thème « {y.content} » {isSussy(y.content)}</li>
        )}
      </ul>
    </div>
  );
}
