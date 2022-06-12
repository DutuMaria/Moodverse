import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, fakeAsync, TestBed, tick } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';

import { LoginComponent } from './login.component';

describe('LoginComponent', () => {
  let component: LoginComponent;
  let fixture: ComponentFixture<LoginComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule
      ],
      declarations: [ LoginComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LoginComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('CHECK Form Group ELEMENT COUNT', () => {
    const formElement = fixture.debugElement.nativeElement.querySelector('#loginForm');
    const inputElements = formElement.querySelectorAll('input');
    expect(inputElements.length).toEqual(2);
  });

  it('CHECK INITIAL FORM VALUES FOR LOGIN FORM GROUP', () => {
    const loginFormGroup = component.loginForm;
    const loginFormValues = {
      email: '',
      password: ''
    }
    expect(loginFormGroup.value).toEqual(loginFormValues);
  });

  it('CHECK EMAIL VALUE Before ENTERING SOME VALUE AND VALIDATION', () => {
    const loginFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement.querySelector('#loginForm').querySelectorAll('input')[0];
    const emailValueFromGroup = component.loginForm.get('email');
    expect(loginFormUserElement.value).toEqual(emailValueFromGroup?.value);
    expect(emailValueFromGroup?.errors).not.toBeNull();
    expect(emailValueFromGroup?.errors?.['required']).toBeTruthy();
  });

  it('CHECK PASSWORD VALUE Before ENTERING SOME VALUE AND VALIDATION', () => {
    const loginFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement.querySelector('#loginForm').querySelectorAll('input')[1];
    const passwordValueFromGroup = component.loginForm.get('password');
    expect(loginFormUserElement.value).toEqual(passwordValueFromGroup?.value);
    expect(passwordValueFromGroup?.errors).not.toBeNull();
    expect(passwordValueFromGroup?.errors?.['required']).toBeTruthy();
  });

  it('CHECK EMAIL VALUE AFTER ENTERING SOME VALUE AND VALIDATION', () => {
    const loginFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement.querySelector('#loginForm').querySelectorAll('input')[0];
    loginFormUserElement.value = 'sample@gmail.com';
    loginFormUserElement.dispatchEvent(new Event ('input')) ;
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const emailValueFromGroup = component.loginForm.get('email');
      expect (loginFormUserElement.value).toEqual(emailValueFromGroup?.value);
      expect (emailValueFromGroup?.errors).toBeNull();
    })
  });

  it('CHECK PASSWORD VALUE AFTER ENTERING SOME VALUE AND VALIDATION', () => {
    const loginFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement.querySelector('#loginForm').querySelectorAll('input')[1];
    loginFormUserElement.value = 'Sample@123';
    loginFormUserElement.dispatchEvent(new Event ('input')) ;
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const passwordValueFromGroup = component.loginForm.get('password');
      expect (loginFormUserElement.value).toEqual(passwordValueFromGroup?.value);
      expect (passwordValueFromGroup?.errors).toBeNull();
    })
  });

  it('CHECK LOGIN FORM IS VALID WHEN VALIDATIONS ARE FULFILLED', () => {
    const loginFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement.
    querySelector('#loginForm').querySelectorAll('input')[0];
    const loginFormPasswordElement: HTMLInputElement = fixture.debugElement.nativeElement.
    querySelector('#loginForm').querySelectorAll('input')[1];
    loginFormUserElement.value = 'clara@gmail.com';
    loginFormPasswordElement.value = 'Clara@123';
    loginFormUserElement.dispatchEvent(new Event ('input'));
    loginFormPasswordElement.dispatchEvent(new Event ('input'));
    const isLoginFormValid = component.loginForm.valid;
    fixture.whenStable().then(() => {
      expect(isLoginFormValid).toBeTruthy;
    })
  });

  it('CHECK BUTTON function doLogin', () => {
    spyOn(component, 'doLogin');
  
    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();
  
    fixture.whenStable().then(() => {
      expect(component.doLogin).toHaveBeenCalled();
    });
  });

});

