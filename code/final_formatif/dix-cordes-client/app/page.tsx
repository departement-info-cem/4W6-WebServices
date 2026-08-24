"use client";

import { useEffect, useRef, useState } from "react";
import { Channel } from "./_types/channel";
import { Message } from "./_types/message";
import { useBinding } from "./_hooks/use-binding";
import { useChat } from "./_hooks/use-chat";

export default function Home() {

  // Hooks
  const chatAPI = useChat();

  // États
  const [selectedChannel, setSelectedChannel] = useState<Channel | null>(null);
  const [selectedMessage, setSelectedMessage] = useState<Message | null>(null);

  const messageText = useBinding("");

  const [reactionOverlay, setReactionOverlay] = useState<boolean>(false);

  const reactionFileInput = useRef<HTMLInputElement>(null);

  useEffect(() => {

    chatAPI.getChannels();

  }, []);

  async function createReaction() {

    if(reactionFileInput.current == null){
        console.log("Référence vide ou élément HTML non visible dans la page.");
        return;
    }

    if(reactionFileInput.current.files == null){
        console.log("L'input ne contient aucun fichier");
        return;
    }

    // Créer le formData est mettre le fichier dedans (Le fichier est un BLOB !)
    const formData = new FormData();
    formData.append("imageReaction", reactionFileInput.current.files[0]);

    await chatAPI.postReaction(selectedMessage!.id, formData);
    selectMessage(false, null);

  }

  async function selectChannel(channel : Channel){

    await chatAPI.getChannelMessages(channel.id);
    setSelectedChannel(channel);

  }

  function selectMessage(overlayIsOn: boolean, message: Message | null) {
    setReactionOverlay(overlayIsOn);
    setSelectedMessage(message);
  }

  return (
    <div>
      <div className="container">
        <div className="channels">
          <h3>Salons textuels 💬</h3>

          {/* Liste des canaux de discussion */}
          {
            chatAPI.channels.map(c =>
              <div key={c.id} onClick={() => selectChannel(c)} className={selectedChannel && selectedChannel.id == c.id ? 'selectedChannel' : 'notSelectedChannel'}>
                # {c.name}
              </div>
            )
          }
          <hr />
          <div id="newChannel">
            <input type="text" placeholder="Nom du canal" />
            <button>Nouveau canal</button>
          </div>

        </div>

        <div className="messages">

          {/* Nom du canal sélectionné */}
          <div className="channelTitle">{selectedChannel != null ? '# ' + selectedChannel.name : 'Sélectionnez un salon... ⏳'}</div>
          <div className="messageList">

            {/* Boucle qui affiche les messages */}
            {
              chatAPI.messages.map(m =>
                <div key={m.id} className="singleMessage">
                  <div className="avatar">
                    <img src="/images/avatar.png" alt="Avatar" />
                  </div>

                  <div className="messageArea">

                    <div className="close" onClick={() => chatAPI.deleteMessage(m.id)}>❌</div>

                    <div className="date">{new Date(m.sentAt).toLocaleString("fr")}</div>

                    {/* Auteur du message */}
                    <div className="nickname">{m.username}</div>

                    {/* Texte du message */}
                    <div className="text">{m.text}</div>

                    <div className="reactions">

                      {/* Afifchage des réactions par message */}
                      {
                        m.reactions.map(r =>
                          <div key={r.id} className={'singleReaction' + (r.isToggled == true ? ' highlight' : '')} onClick={() => chatAPI.toggleReaction(r, m.id)}>
                            <img src="/images/question.png" alt="Reaction" />
                            <div>{r.quantity}</div>
                          </div>
                        )
                      }

                      <div className="singleReaction" onClick={() => selectMessage(true, m)}>
                        ➕
                      </div>
                    </div>
                  </div>
                </div>

              )
            }

          </div>

          {/* Formulaire pour poster un nouveau message dans le canal sélectionné */}
          {
            selectedChannel &&
            <div className="newMessage">
              <div>
                <textarea {...messageText} placeholder={'Écrivez un message dans ' + selectedChannel.name + '...'}></textarea>
              </div>
              <div>
                <button><img src="/images/envoyer.png" alt="Envoyer" onClick={() => chatAPI.postMessage(messageText.value, selectedChannel.id)} /></button>
              </div>

            </div>
          }

        </div>

      </div>

      {/* Formulaire pour ajouter une réaction à un message */}
      {
        reactionOverlay &&
        <div className="newReactionOverlay" >
          <div className="close" onClick={() => selectMessage(false, null)}>
            ❌
          </div>
          <div className="newReaction">
            <input type="file" ref={reactionFileInput} accept="images/*" /><button onClick={createReaction}>Réagir</button>
          </div>
        </div>
      }
    </div>
  );
}
