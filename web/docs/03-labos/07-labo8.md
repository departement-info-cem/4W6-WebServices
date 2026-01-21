# Laboratoire 8 💩

Téléchargez le [projet de départ](../../static/files/labo8.zip) et réinstallez les dépendances.

Vous n'aurez pas à installer `@angular/google-maps` car ça a déjà été fait pour vous 🙄

:::warning

Contrairement aux laboratoires précédents, celui-ci a été fait avec Angular 20, donc les composants sont nommés sans le suffixe `Component`.
Par exemple, les fichiers du composant `youtubeSearch` se nomment simplement `youtube-search...` plutôt que `youtube-search.component...`.

Vous devriez réussir à vous retrouver malgré tout.

:::

### 🎥 1 - À la merci de l'algorithme YouTube

Cette partie utilisera le composant `youtubeSearch` et le `GoogleService`. Le but est de permettre à l’utilisateur de chercher une vidéo Youtube grâce au formulaire. La première vidéo trouvée par l’API YouTube Data sera affichée en-dessous.

[💡](/cours/rencontre4.2#-requête-youtube) Commencez par vous créer un compte Gougueule (ou utilisez un compte existant) et suivre les étapes pour obtenir une clé d’API.
* ⛔ N'oubliez pas d'activer l'API Youtube Data également.
* Dans le `GoogleService`, remplissez la constante `googleApiKey`.

:::tip

Il n'y aura rien à changer dans le HTML du composant `youtubeSearch` 😩

:::

[💡 (Étape 3)](/cours/rencontre4.2#-intégration-youtube) Dans la classe du composant `youtubeSearch`, vous devrez compléter la fonction `searchVideo()`. Elle « *sanitize* » l’URL d’une vidéo YouTube (obtenue en concaténant la constante `youtubeURL` et `this.videoId`) et glisse ensuite cet URL sanitizé dans `this.videoUrl`.

Une fois que c’est fait, vous devriez être capable de faire apparaître une vidéo d’ASMR en tapant n’importe quoi dans le formulaire de recherche. La prochaine étape sera de pouvoir chercher une autre vidéo. (De notre choix)

[💡 (Étape 3)](/cours/rencontre4.2#-requête-youtube) Dans le `GoogleService`, ajoutez une requête qui permet d’obtenir l’**id** de la première vidéo trouvée avec le texte (`searchText`) fourni en paramètre.

Une fois que ce sera (bien) fait, le texte donné au formulaire sera pris en compte pour la recherche.

### 🌐 2 - Une globe-trotteuse compulsive

Cette partie utilisera le composant `swift`. C'est normal que la carte Google s'affiche potentiellement mal au début.

[💡 (Étape 3)](/cours/rencontre4.2#-intégration-google-maps) À l’aide de votre (même) clé d’API Google, complétez l’importation du script dans index.html.

La carte Google devrait mieux s’afficher maintenant. (Vous pouvez vous promener dedans)

:::warning

C'est normal qu'une erreur de facturation soit affichée. Nous n'utiliserons pas la version payante de cette API.

:::

[💡](/cours/rencontre4.2#-ajouter-des-marqueurs-sur-une-carte) Créez une variable de classe dans le composant `swift` qui contiendra un tableau de marqueurs à mettre sur la map Google. Initialement, mettez déjà un marqueur avec la latitude `42` et la longitude `-4` dans ce tableau.

* Modifiez le template HTML pour que tous les (éventuels) marqueurs soient affichés dans la map Google.
* Complétez la fonction `addMarker()` pour permettre à l’utilisateur d’ajouter des marqueurs dans cette variable.
* Complétez la fonction `clearMarkers()` pour permettre à l’utilisateur de vider le tableau de marqueurs.

### 💪 3 - Se faire des pipes

Cette partie utilisera le composant `plumbing`.

[💡](/cours/rencontre4.2#-créer-un-pipe) Créez un sous-dossier nommé `pipe` dans le dossier `app` pour y créer un nouveau pipe nommé `special`.

* Le but de ce pipe sera de prendre une chaîne de caractères en input, de mettre un caractère sur deux en majuscules et les autres en minuscules. Quoi ? Vous êtes paresseux ? 🦥 Vous ne voulez pas coder l'algorithme vous-mêmes ? Okay ... voici le code ... :

```ts showLineNumbers
x = x.toLowerCase();
for(let i = 0; i < x.length; i++){
    if(i % 2 == 1){
        x = x.substring(0, i) + x.charAt(i).toUpperCase() + x.substring(i + 1);
    }
}
return x;
```

La variable `x` peut être remplacée par un autre nom... Ce n'est pas grave d'être paresseux pour cette fois, mais en général, dans la vie, sachez qu'il faut vraiment [... *yapping* paternaliste inaudible ...].

* N'oubliez pas de changer le type du paramètre `input` pour `any`, ça vous permettra de manipuler l'`input` comme vous le désirez.

Une fois votre pipe complété, rendez-vous dans le composant `plumbing` et utilisez votre nouveau pipe pour transformer le texte « Ce texte était agréable à lire avant qu’il ne devienne spécial ».

[💡](/cours/rencontre4.2#-pipe-pour-le-formatage-des-dates) Nous utiliserons le `DatePipe` (qui existe déjà par défaut. Pas besoin de le créer) pour modifier l'affichage des trois dates dans le HTML du composant `plumbling`. Le but est d'obtenir le résultat affiché dans la colonne de droite du tableau.

* 🥖🧀 Il faudra installer la *locale* `fr` pour réussir à bien afficher la deuxième dans le dialecte communément appelé `Français`.

🥳 Bon travail !