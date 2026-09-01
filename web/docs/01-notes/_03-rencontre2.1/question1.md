Qu'est-ce qui s'affiche dans la console quand je clique une première, puis une deuxième fois sur le bouton ?

```tsx
const [score, setScore] = useState(0);
function handleClic() {
  setScore(score + 10);
  console.log(score);
}
```
