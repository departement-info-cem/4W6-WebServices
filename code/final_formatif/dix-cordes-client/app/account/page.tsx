"use client";

import { useAccount } from "../_hooks/use-account";
import { useBinding } from "../_hooks/use-binding";

export default function Account() {

    const { register, login, logout } = useAccount();

    const logUsername = useBinding("");
    const logPassword = useBinding("");

    const regUsername = useBinding("");
    const regPassword = useBinding("");
    const regPasswordConfirm = useBinding("");

    return (
        <div className="container">
            <div className="login">

                <div>
                    <h3>Connexion</h3>
                    <table>
                        <tbody>
                            <tr>
                                <td>Nom d'utilisateur</td>
                                <td><input type="text" name="loginUsername" {...logUsername} /></td>
                            </tr>
                            <tr>
                                <td>Mot de passe</td>
                                <td><input type="text" name="loginPassword" {...logPassword} /></td>
                            </tr>
                        </tbody>
                    </table>
                    <button onClick={() => login(logUsername.value, logPassword.value)}>Se connecter</button>

                    <h3 className="spaceUp">Déconnexion</h3>
                    <button onClick={() => logout()}>Se déconnecter</button>
                </div>

            </div>
            <div className="register">

                <div>
                    <h3>Inscription</h3>
                    <table>
                        <tbody>
                            <tr>
                                <td>Nom d'utilisateur</td>
                                <td><input type="text" name="registerUsername" {...regUsername} /></td>
                            </tr>
                            <tr>
                                <td>Mot de passe</td>
                                <td><input type="text" name="registerPassword" {...regPassword} /></td>
                            </tr>
                            <tr>
                                <td>Confirmer le mot de passe</td>
                                <td><input type="text" name="registerPasswordConfirm" {...regPasswordConfirm} /></td>
                            </tr>
                        </tbody>
                    </table>
                    <button onClick={() => register(regUsername.value, regPassword.value, regPasswordConfirm.value)}>S'inscrire</button>
                </div>

            </div>
        </div>
    );

}