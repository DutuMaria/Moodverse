import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-index',
  templateUrl: './index.component.html',
  styleUrls: ['./index.component.scss']
})
export class IndexComponent implements OnInit {
  public isEnabled: boolean = true;

  constructor() { }

  ngOnInit(): void {
    this.getUserStatus();
  }

  getUserStatus(){
    if("currentUser" in sessionStorage){
      this.isEnabled = false;
    }
  }

}
