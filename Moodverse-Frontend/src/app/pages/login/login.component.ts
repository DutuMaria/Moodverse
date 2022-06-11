import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder:FormBuilder, private router:Router, private authenticationService:AuthenticationService) { }
  public text:string = '';

  public loginForm!:FormGroup;

  public logged:boolean = false;
  public notLogged:boolean = true;

  ngOnInit(): void {
    this.text = "LOGIN";
    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      }
    );
  }

  doLogin(){
    if(this.loginForm.valid){
      this.authenticationService.login(this.loginForm.value)
      .subscribe((response:any)=>{
        // console.log(response);
        // this.dashboardComponent.isNotLogged = false;
        // this.dashboardComponent.isLogged = true;
        // localStorage.setItem('currentUser', this.loginForm.value.email);
        // this.loggedService.setLogged();
        // this.notLogged = this.loggedService.getIsNotLogged();
        // this.logged = this.loggedService.getIsLogged();
        // console.log("Not ", this.notLogged);
        // console.log("log ", this.logged);
        this.router.navigateByUrl('/index');
      })
    }
  }
}
