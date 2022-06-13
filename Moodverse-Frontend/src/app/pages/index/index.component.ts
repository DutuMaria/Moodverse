import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { QuoteService } from 'src/app/services/quote.service';
import { StreakService } from 'src/app/services/streak.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  public isEnabled: boolean = true;
  backgrounds: boolean = false;
  ambiences: boolean = false;
  quotes: boolean = false;
  todolists: boolean = false;
  quoteOfTheDay!: string;
  quoteExists!: false;
  streakNumber: number = 0;
  constructor(private quoteService:QuoteService,private streakService:StreakService , private router:Router) { }

  ngOnInit(): void {
    this.getUserStatus();
  }

  getUserStatus(){
    if("currentUser" in sessionStorage){
      this.isEnabled = false;
    }
  }

  streakFunction(){ //apelat la login?
    this.streakService.getStreakNumber().subscribe((response:any) =>{
      //sessionStorage.setItem("Streak", response);
      this.streakNumber = response;
    });
    //update streak apelat la login
    //create streak apelat la register
  }
    
  backgroundsFunction(){
    if(this.backgrounds == true) this.backgrounds = false;
    else this.backgrounds = true;
  }

  ambiencesFunction(){
    if(this.ambiences == true) this.ambiences = false;
    else this.ambiences = true;
  }

  quotesFunction(){
    if(this.quotes == true) {this.quotes = false;}
    else {
      this.quotes = true;
      let quotesList = [];
      let lenQuotesList;
      let randomIndex;
      let message = '';

      this.quoteService.getAllQuotes().subscribe((response:any) => {
        quotesList = response;
        lenQuotesList = quotesList.length;
        randomIndex = this.getRandomInt(lenQuotesList);
        message = quotesList[randomIndex].message;

        sessionStorage.setItem("DailyQuote", message);
      })

      if ("DailyQuote" in sessionStorage){
        this.quoteOfTheDay = sessionStorage.getItem("DailyQuote")!;
      }
      console.log(this.quoteOfTheDay);
    }
  }

  todolistsFunction(){
    if(this.todolists == true) this.todolists = false;
    else this.todolists = true;
  }

  doLogout(){
    sessionStorage.removeItem("currentUser");
    this.isEnabled = true;
  }

  randomQuote(){
    let quote = ''
    let quotesList = [];
    let lenQuotesList;
    let randomIndex;

    this.quoteService.getAllQuotes().subscribe((response:any) => {
      quotesList = response;
      lenQuotesList = quotesList.lenght
      randomIndex = this.getRandomInt(lenQuotesList);

      this.quoteOfTheDay = quotesList[randomIndex];
    })
    
    return quote;
  }

  getRandomInt(max:any) {
    return Math.floor(Math.random() * max);
  }
}
