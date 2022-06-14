import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AppPrivateService } from 'src/app/services/app-private.service';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private privateService: AppPrivateService, private formBuilder: UntypedFormBuilder, private router: Router, private authenticationService: AuthenticationService) { }
  public text: string = '';
  public loginForm!: UntypedFormGroup;
  public logged: boolean = false;
  public notLogged: boolean = true;
  public admin: boolean = false;

  ngOnInit(): void {
    this.text = "LOGIN";

    this.loginForm = this.formBuilder.group(
      {
        email: ['', [Validators.required, Validators.email]],
        password: ['', [Validators.required]]
      }
    );
  }

  getAdminStatus() {
    let currentUsername = sessionStorage.getItem("currentUser");
    this.privateService.checkIfAdmin(currentUsername!).subscribe(
      (response: any) => {
        sessionStorage.setItem("checkIfAdmin", response);

        this.setAdminStatus();
        // console.log(sessionStorage.getItem("checkIfAdmin"));

        if (sessionStorage.getItem("checkIfAdmin") == "true") {
          this.router.navigate(['/adminPage']);
          return;
        }
      })
  }

  setSessionUser() {
    sessionStorage.setItem("currentUser", this.loginForm.value.email);
  }

  setAdminStatus() {
    if (sessionStorage.getItem("checkIfAdmin") == "true") {
      this.admin = true;
    }
    else {
      this.admin = false;
    }
  }

  doLogin() {
    if (this.loginForm.valid) {
      this.authenticationService
        .login(this.loginForm.value)
        .subscribe((response: any) => {
          if (response.success == false) {
            alert("Username or password invalid");
            this.loginForm.reset();
          }
          else {
            this.setSessionUser();
            this.getAdminStatus();
            this.router.navigate(['/index']);
          }
        });
    }
  }
}
