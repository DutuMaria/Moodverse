import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, ValidatorFn, AbstractControl, ValidationErrors } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { StreakService } from 'src/app/services/streak.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})

export class RegisterComponent implements OnInit {
  public registerForm!:FormGroup;
  public text:string = '';

  // cu formBuilder se creeaza un form group
  constructor(private formBuilder:FormBuilder, private router:Router, private authenticationService:AuthenticationService, private streakService: StreakService) { }

  ngOnInit(): void {
    this.text = "REGISTER";
    this.registerForm = this.formBuilder.group(
      {
        email : ['', [Validators.required, Validators.email]],
        // username : ['', [Validators.required]],
        password : ['', [Validators.required]],
        confirmPassword : ['', [Validators.required]],
        role : ['User']
      }, { validators: this.checkPasswords }
    );
  }

  checkPasswords: ValidatorFn = (group: AbstractControl):  ValidationErrors | null => { 
    // ? nu da eroare daca parola e null
    let password = group.get('password')?.value;
    let confirmPassword = group.get('confirmPassword')?.value
    return password === confirmPassword ? null : { passwordsMismatched: true }
  }

  doRegister(){
    console.log(this.registerForm);
    if (this.registerForm.valid) {
      this.authenticationService
        .register(this.registerForm.value)
        .subscribe((response: any) => {
          console.log(response);
          this.streakService.createStreak().subscribe((response:any) => {
            console.log(response);
          })
        });
    }
    this.router.navigate(['/login']);
  }
}
