import { Component, OnInit } from '@angular/core';

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
  constructor() { }

  ngOnInit(): void {
    this.getUserStatus();
  }

  getUserStatus(){
    if("currentUser" in sessionStorage){
      this.isEnabled = false;
    }
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
    if(this.quotes == true) this.quotes = false;
    else this.quotes = true;
  }

  todolistsFunction(){
    if(this.todolists == true) this.todolists = false;
    else this.todolists = true;
  }

}
