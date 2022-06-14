import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  public username!: string | null;
  constructor() { }

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    console.log(sessionStorage.getItem("currentUser"))
    this.username = sessionStorage.getItem("currentUser");
  }

}
