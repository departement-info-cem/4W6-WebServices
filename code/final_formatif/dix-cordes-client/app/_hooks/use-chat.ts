import { apiDomain } from "@/next.config";
import { Channel } from "../_types/channel";
import { Message } from "../_types/message";
import { Reaction } from "../_types/reaction";
import { dixCordes } from "../dixcordes-interceptor";
import { useState } from "react";

export function useChat() {

    const [channels, setChannels] = useState<Channel[]>([]);
    const [messages, setMessages] = useState<Message[]>([]);

    async function postChannel(name : string){

        // Appeler une requête ici


        // Décommentez ce code éventuellement pour mettre à jour la liste des canaux immédiatement 
        // (x.data devra contenir le nouveau canal, retourné par l'action PostChannel du serveur)
        // setChannels([...channels, x.data]);

    }

    // Obtenir la liste des canaux
    async function getChannels() {
        const x = await dixCordes.get(apiDomain + "/api/Channels/GetChannel");
        console.log(x.data);
        
        setChannels(x.data);
    }

    // Obtenir les messages d'un canal
    async function getChannelMessages(channelId: number) {
        const x = await dixCordes.get(apiDomain + "/api/Messages/GetChannelMessages/" + channelId);
        console.log(x.data);
        
        setMessages(x.data);
    }

    // Créer un message
    async function postMessage(inputText: string, channelId: number) {
        let messageDTO = {
            text: inputText,
            channelId: channelId
        };
        const x = await dixCordes.post(apiDomain + "/api/Messages/PostMessage", messageDTO);
        console.log(x.data);
        
        // Ajout du message dans la page
        setMessages([...messages, x.data]);
    }

    // Supprimer un message
    async function deleteMessage(messageId: number) {
        try {
            const x = await dixCordes.delete(apiDomain + "/api/Messages/DeleteMessage/" + messageId);
            console.log(x.data);

            // Retrait du message dans la page
            setMessages(messages.filter(m => m.id != messageId));
        }
        catch {
            console.log("Impossible : vous n'êtes pas l'auteur !")
        }
    }

    // Se joindre ou se retirer d'une réaction
    async function toggleReaction(reaction: Reaction, messageId : number) {
        const x = await dixCordes.put(apiDomain + "/api/Reactions/ToggleReaction/" + reaction.id, null);
        console.log(x.data);
        
        // Mise à jour immédiate de la réaction dans la page (Oui c'est laid)
        const editedMessages = [...messages];
        const editedMessage = editedMessages.find(m => m.id == messageId);
        const editedReaction = editedMessage!.reactions.find(r => r.id == reaction.id);
        editedReaction!.quantity += editedReaction!.isToggled ? -1 : 1;
        if(editedReaction!.quantity == 0) editedMessage!.reactions = editedMessage!.reactions.filter(r => r.id != reaction.id);
        else editedReaction!.isToggled = !editedReaction!.isToggled;
        setMessages(editedMessages);
    }

    // Créer une nouvelle réaction
    async function postReaction(messageId: number, formData: FormData) {
        const x = await dixCordes.post(apiDomain + "/api/Reactions/PostReaction/" + messageId, formData);
        console.log(x.data);
        
        // Mise à jour immédiate de la page pour ajouter la nouvelle réaction
        const editedMessages = [...messages];
        const editedMessage = editedMessages.find(m => m.id == messageId);
        editedMessage!.reactions.push(x.data);
        setMessages(editedMessages);
    }

    return { 
        
        // États
        channels, messages,
        
        // Requêtes
        postChannel, getChannels, getChannelMessages, postMessage, deleteMessage, toggleReaction, postReaction 

    };

}