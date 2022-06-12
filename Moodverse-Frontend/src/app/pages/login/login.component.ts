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
    console.log(this.loginForm);
    if (this.loginForm.valid) {
      this.authenticationService
        .login(this.loginForm.value)
        .subscribe((response: any) => {
          console.log(response);
        });
      sessionStorage.setItem("currentUser", this.loginForm.value.email);
      this.router.navigate(['/index']);
    }
  }
}
