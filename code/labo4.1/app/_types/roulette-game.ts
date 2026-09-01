
export class RouletteGame{

  constructor(){}

  money : number = 30;
  amount : number = 0;
  ballSpeed : number = 0;
  ballTheta : number = 0;
  ballMover : any;
  gameActive : boolean = false;
  bet : any;

  startGame(bet : any, amount : number){

    if(this.gameActive){
      return;
    }
    this.money -= amount;
    this.amount = amount;
    this.bet = bet;
    this.gameActive = true;
    this.ballMover = setInterval(this.moveBall.bind(this), 25);
    this.ballSpeed = Math.round(Math.random() * 37) + 74;
    document.getElementById("rouletteMoney")!.textContent = `💰 ${this.money} 💰`;

  }

  moveBall(){

    if(this.ballSpeed <= 0){
      clearInterval(this.ballMover);
      this.gameActive = false;
      this.ballTheta = this.ballTheta % (Math.PI * 2);
      let betTheta = (3.02 * Math.PI / 2 + this.bet * Math.PI / 37) % (Math.PI * 2);
      if(this.bet == "red"){
        betTheta = (Math.round(this.ballTheta * 37.04 / (Math.PI * 2)) + 9) % 37;
        console.log(betTheta);
        if(betTheta % 2 == 1){
          document.getElementById("messageRoulette")!.textContent = `+${this.amount * 2} $ 🤑`;
          this.money += this.amount * 2;
        }
        else{
          document.getElementById("messageRoulette")!.textContent = `-${this.amount} $ 😥`;
        }
      }
      else if(this.bet == "black"){
        betTheta = (Math.round(this.ballTheta * 37.04 / (Math.PI * 2)) + 9) % 37;
        if(betTheta > 0 && Math.round(betTheta) % 2 == 0){
          document.getElementById("messageRoulette")!.textContent = `+${this.amount * 2} $ 🤑`;
          this.money += this.amount * 2;
        }
        else{
          document.getElementById("messageRoulette")!.textContent = `-${this.amount} $ 😥`;
        }
      }
      else if(this.bet != undefined){
        let diff = Math.PI / (37 * 2);
        //betTheta = betTheta < 0 ? betTheta + 2 * Math.PI : betTheta;
        console.log("Pari : " + betTheta);
        console.log("Position : " + this.ballTheta);
        if(Math.abs(betTheta - this.ballTheta) < diff){
          document.getElementById("messageRoulette")!.textContent = `+${this.amount * 30} $ 🤑`;
          this.money += this.amount * 30;
        }
        else{
          document.getElementById("messageRoulette")!.textContent = `-${this.amount} $ 😥`;
        }
      }
      document.getElementById("rouletteMoney")!.textContent = `💰 ${this.money} 💰`;
    }
    else{
      this.ballTheta += Math.PI / 740 * this.ballSpeed;
      this.ballSpeed -= 0.5;
      let left = 199 + Math.cos(this.ballTheta) * 130;
      let top = 197 + Math.sin(this.ballTheta) * 130;
      document.getElementById("ball")!.style.left = left + "px";
      document.getElementById("ball")!.style.top = top + "px";
    }

  }

}