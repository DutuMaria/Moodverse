import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ConnectableObservable } from 'rxjs';
import { AmbienceService } from 'src/app/services/ambience.service';
import { AppPrivateService } from 'src/app/services/app-private.service';
import { BackgroundService } from 'src/app/services/background.service';
import { QuoteService } from 'src/app/services/quote.service';
import { StreakService } from 'src/app/services/streak.service';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  public isEnabled: boolean = true;
  public admin: boolean = false;
  backgrounds: boolean = false;
  ambiences: boolean = false;
  quotes: boolean = false;
  todolists: boolean = false;
  quoteOfTheDay: string = "The bad news is time flies. The good news is you’re the pilot.";
  author: string = "Walt Whitman";
  quoteExists!: false;
  streakNumber: number = 0;
  public users:any[]=[];
  public backgroundsList:any[]=[];
  public currentBackground:string= "/assets/pauline-heidmets-GTL39WM6QqA-unsplash.jpg";
  public ambiencesList:any[]=[];

  constructor(private privateService:AppPrivateService,private ambienceService:AmbienceService, private streakService:StreakService, private quoteService:QuoteService, private backgroundService:BackgroundService, private router:Router) { }

  ngOnInit(): void {
    this.getUserStatus();
    this.getAllBackgrounds();
    this.getAllAmbiences();
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
      let currentAuthor = '';

      this.quoteService.getAllQuotes().subscribe((response:any) => {
        quotesList = response;
        lenQuotesList = quotesList.length;
        randomIndex = this.getRandomInt(lenQuotesList);
        message = quotesList[randomIndex].message;
        currentAuthor = quotesList[randomIndex].author;

        sessionStorage.setItem("DailyQuote", message);
        sessionStorage.setItem("AuthorDailyQuote", currentAuthor);
      })

      if ("DailyQuote" in sessionStorage && "AuthorDailyQuote" in sessionStorage){
        this.quoteOfTheDay = sessionStorage.getItem("DailyQuote")!;
        this.author = sessionStorage.getItem("AuthorDailyQuote")!;
      }
      console.log(this.quoteOfTheDay);
      console.log(this.author);
    }
  }

  todolistsFunction(){
    if(this.todolists == true) this.todolists = false;
    else this.todolists = true;
  }

  doLogout(){
    sessionStorage.removeItem("currentUser");
    sessionStorage.clear();
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

  getAllUsers(){
    this.privateService.getAllUsers().subscribe((response:any)=>{
      this.users=response.allUsers;
    });
  }

  getAllBackgrounds(){
    this.backgroundService.getAllBackgrounds().subscribe((response:any)=>{
      this.backgroundsList=response;
    });
  }

  changeBackground(src:string){
    console.log(src);
    this.currentBackground="/assets/" + src;

  }

  getAllAmbiences(){
    this.ambienceService.getAllAmbiences().subscribe((response:any)=>{
      this.ambiencesList=response;
      console.log(this.ambiencesList[0]);
    })
  }

}
