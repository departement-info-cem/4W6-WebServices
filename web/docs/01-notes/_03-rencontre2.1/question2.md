Est-ce que ce code va mettre à jour l'affichage sur la page Web ? Pourquoi ?

```tsx
const [fruits, setFruits] = useState(["Pomme", "Banane"]);

function ajouterFruit() {
  fruits.push("Kiwi");
  setFruits(fruits);
}
```