---
title: "12.1 - Git et TP4"
---

## 👥 Git à deux

Fonctionnement général :

* Nous n'allons jamais **merge** dans `main`. (Seulement une fois, à la fin du TP)
* À chaque nouvelle fonctionnalité à implémenter, on crée une **branche** à partir de la branche `dev`.
* Une fois une fonctionnalité terminée, on **merge** `dev` dans la branche de la fonctionnalité pour d'abord résoudre les conflits.
* Une fois les conflits résolus, on pourra faire l'inverse : **merge** la branche de la fonctionnalité dans `dev`.
* Puis on recommence pour la prochaine fonctionnalité.
* Chaque partenaire travaille toujours **seul(e) sur sa propre branche**.

### 🌳 Exemple concret

1. Au début du projet, seule la branche `main` existe.

<center>![Résumé du processus](../../static/img/cours22/dessin1.png)</center>

<hr/>

2. On crée immédiatement la branche `dev`.

<center>![Résumé du processus](../../static/img/cours22/dessin2.png)</center>

<hr/>

3. Les deux partenaires créent chacun une **branche** pour travailler sur leur propre fonctionnalité.

<center>![Résumé du processus](../../static/img/cours22/dessin3.png)</center>

<hr/>

4. Les deux partenaires font des **commits** et avancent leur fonctionnalité. La fonctionnalité `b` est terminée, un des partenaires est prêt à **merge**.

<center>![Résumé du processus](../../static/img/cours22/dessin4.png)</center>

<hr/>

5. Puisque c'est la **toute première fonctionnalité** et qu'aucun **merge** n'a eu lieu, pour la seule fois du projet, on peut **merge** directement `b` dans `dev`.

<center>![Résumé du processus](../../static/img/cours22/dessin5.png)</center>

<hr/>

6. Une fois que `b` a été **merge** dans `dev`, le partenaire crée une nouvelle **branche** pour travailler sur la fonctionnalité `c`.

<center>![Résumé du processus](../../static/img/cours22/dessin6.png)</center>

<hr/>

7. Un peu plus tard, la fonctionnalité `a` est terminée et l'autre partenaire est prêt pour un **merge**.

<center>![Résumé du processus](../../static/img/cours22/dessin7.png)</center>

<hr/>

8. Pour cette fonctionnalité **et toutes les suivantes**, il faudra d'abord **merge** `dev` dans la branche de la fonctionnalité. (Ici, `a`) Dans certaines situations, il y aura des **conflits ⚠**. (Bouts de code modifiés par les deux partenaires ! Quelles modifications conserver ?) 

<center>![Résumé du processus](../../static/img/cours22/dessin8.png)</center>

<hr/>

9. S'il y a des **conflits ⚠** à régler, on fait un **commit supplémentaire** dans le but de les régler et de s'assurer que toutes les fonctionnalités sont intactes. 

<center>![Résumé du processus](../../static/img/cours22/dessin9.png)</center>

<hr/>

10. Enfin, lorsqu'on est sûr que tous les conflits sont réglés, on **merge** la branche dans `dev`. Il n'y aura **aucun conflit** cette fois, comme ils ont déjà été réglés.

<center>![Résumé du processus](../../static/img/cours22/dessin10.png)</center>

<hr/>

11. Ensuite, le partenaire peut recréer une nouvelle **branche** pour sa prochaine fonctionnalité. Les étapes **8** à **10** pourront être répétées pour **toutes les nouvelles branches**.

<center>![Résumé du processus](../../static/img/cours22/dessin11.png)</center>

<hr/>

12. Une fois toutes les fonctionnalités **terminées** et **merge** dans `dev`, si tout fonctionne bien, on peut **merge** dans `main`, pour livrer et / ou déployer le **produit fini**.

<center>![Résumé du processus](../../static/img/cours22/dessin12.png)</center>

:::tip

* N'oubliez pas de faire des **push** fréquents si vous souhaitez que votre partenaire puisse voir vos commits, branches et merges.
N'oubliez pas de faire un **pull** si vous souhaitez voir le progrès de votre partenaire. (Surtout avant de merge dans `dev`)

:::

## 🥚 Setup initial du repo

1. Créer le repo sur Github

<center>![Nouveau repository](../../static/img/cours22/newRepo.png)![Nouveau repository privé](../../static/img/cours22/private.png)</center>

<center>![URL pour cloner](../../static/img/cours22/url.png)</center>

2. Cloner le repo avec **Fork** et y glisser les fichiers de départ.

<center>![Cloner](../../static/img/cours22/cloner.png)</center>

<center>![Cloner](../../static/img/cours22/cloner2.png)</center>

3. Commit les fichiers de départ sur `main`, puis créer une branche `dev` puis push `dev`.

<center>![Commit dans main](../../static/img/cours22/commitMain2.png)</center>

<center>![Bouton pour commit](../../static/img/cours22/commitButton.png)</center>

<center>![Bouton nouvelle branche](../../static/img/cours22/newBranch2.png)</center>

<center>![Menu nouvelle branche](../../static/img/cours22/newBranchMeny.png)  
N'oubliez pas de push `dev` !</center>

<center>![Push la branche dev](../../static/img/cours22/pushDev.png)</center>

4. Ajouter le partenaire en collaborateur et cloner de son côté

5. Faire chacun votre sous-branche dans `dev`

<center>![Sous-branches dans dev](../../static/img/cours22/subBranchDev.png)</center>

Tant que vous n'aurez pas chacun fait un commit dans votre sous-branche, elles seront toutes embarqués les unes sur les autres comme ceci :
<center>![Sous-branches dans dev](../../static/img/cours22/subBranchDev2.png)</center>

<center>![Sous-branches dans dev](../../static/img/cours22/subBranchDev3.png)</center>

:::danger

Attention de bien sélectionner (double-clic) la bonne branche avant de commencer à coder !

:::

## 🌌 Merge de branches

Il est crucial de **d'abord merge `dev` dans votre sous-branche**, de résoudre les conflits sur votre sous-branche, puis, une fois que vous avez tout testé, de finalement **merge votre sous-branche dans `dev`**. De cette manière, `dev` est censée être toujours fonctionnelle.

S'il n'y a aucun autre merge dans `dev` depuis que vous avez créé votre sous-branche, il n'y aura pas de conflits et vous pourrez directement **merge dans `dev`**.

1. Sélectionner votre branche et merge `dev` dedans :

<center>![Avant le merge](../../static/img/cours22/preMerge.png)</center>

<center>
    ![Sélectionner la bonne branche](../../static/img/cours22/selectBranch.png)
    ![Merge dev dans Etape-2](../../static/img/cours22/mergeIntoDev.png)
</center>

<center>![Avertissement de conflits](../../static/img/cours22/conflicts.png)</center>

2. Résoudre les conflits (s'il y en a)

🚪 Notez qu'il faudra faire la gestion de conflits dans `Visual Studio` et dans `VS Code`. L'exemple ci-dessous est avec `VS Code`.

<center>![VS Code avec conflits](../../static/img/cours22/vsCode.png)</center>
<center>![Bouton vers éditeur de fusion](../../static/img/cours22/fusion.png)</center>

L'objectif est de s'assurer que le **code en bas** correspond au résultat souhaité. Vous pouvez l'éditer manuellement au besoin en vous servant des deux versions en conflit qui sont en haut.

<center>![VS Code avec conflits](../../static/img/cours22/fusion2.png)</center>

Il va falloir faire un aller-retour entre VS Code et Fork **pour chaque fichier**.

:::warning

S'il y a plusieurs fichiers en conflit, réglez-les dans l'ordre suivant :

1. Modèles
2. Services
3. Contrôleurs / composants

Inutile de gérer les conflits pour les migrations ! Au pire, supprimez les migrations et recréez-en sur votre prochaine branche.

:::

3. Retourner dans **Fork** pour conclure le merge

<center>![Merge terminé dans Fork](../../static/img/cours22/endMerge.png)</center>

4. ⛔ TESTEZ votre code.

S'il y a des bugs, faites un commit supplémentaire sur votre sous-branche pour les régler AVANT de **merge dans `dev`**.

5. Merge dans `dev`

<center>![Merge dans dev](../../static/img/cours22/mergeIntoDev2.png)</center>

<center>![Merge dans dev terminé](../../static/img/cours22/mergeFinished.png)</center>

## 🤕 Erreurs fréquentes

### 🌿 J'ai travaillé sur la mauvaise branche

Par exemple, avoir fait un commit sur `dev` plutôt que dans une sous-branche : 

<center>![Commit sur dev](../../static/img/cours22/mauvaiseBranche1.png)</center>

Commencez par **créer une nouvelle branche** à partir de ce commit de trop :

<center>![Nouvelle branche](../../static/img/cours22/mauvaiseBranche2.png)</center>

Sélectionner `dev` :

<center>![Branche dev sélectionnée](../../static/img/cours22/mauvaiseBranche3.png)</center>

Pour ensuite faire un clic-droit sur le **commit précédent** et réinitialiser la branche `dev` à ce commit :

<center>![Branche dev réinitialisée](../../static/img/cours22/mauvaiseBranche4.png)</center>

Pour le moment, cela va « dupliquer » la branche `dev` :

<center>![Branche dev dupliquée](../../static/img/cours22/mauvaiseBranche5.png)</center>

Il suffira de faire un **push** (« force push ») pour que seule la nouvelle branche `dev` soit conservée :

<center>![Force push](../../static/img/cours22/mauvaiseBranche6.png)</center>

<center>![Problème réglé](../../static/img/cours22/mauvaiseBranche7.png)</center>

### ⏳ Revenir en arrière (annuler un commit)

Disons qu'on souhaite annuler le tout dernier commit qu'on a fait :

<center>![Mauvais commit](../../static/img/cours22/annulerCommit1.png)</center>

Faites un clic-droit sur le commit précédent et **réinitialisez votre branche** à celui-ci :

<center>![Réinitialiser le commit](../../static/img/cours22/annulerCommit2.png)</center>

Après avoir fait un **push** (force push), vous devriez avoir ce résultat :

<center>![Commit réinitialisé](../../static/img/cours22/annulerCommit3.png)</center>

### 💥 Merge simultané accidentel

Disons que votre partenaire et vous avez fait un **merge** dans `dev` en même temps... Vous aurez des problèmes lors de votre prochain **pull** puisque la branche `dev` existera en deux versions !

Avant les merge :

<center>![Avant le double merge](../../static/img/cours22/doubleMerge1.png)</center>

Merge réalisé par la personne 1 :

<center>![Premier merge](../../static/img/cours22/doubleMerge2.png)</center>

Merge réalisé par la personne 2 :

<center>![Deuxième merge](../../static/img/cours22/doubleMerge3.png)</center>

Lorsque les deux personnes feront un **push**, la première personne qui fera un **pull** aura ce problème : il y a deux versions de `dev` !

<center>![Branche dev dupliquée](../../static/img/cours22/doubleMerge4.png)</center>

La solution sera de **merge** `dev` dans `dev` (oui oui) Alternativement, on peut aussi merge la branche `dev` générée par notre partenaire dans notre sous-branche à nous pour ne pas avoir à **gérer les conflits** directement sur `dev`. 

<center>![Merge dev dans dev](../../static/img/cours22/doubleMerge5.png)</center>

<center>![Merge dev dans dev](../../static/img/cours22/doubleMerge6.png)</center>

Résultat : (N'oubliez pas de **push** `dev` ensuite !)

<center>![Merge dev dans dev](../../static/img/cours22/doubleMerge7.png)</center>
