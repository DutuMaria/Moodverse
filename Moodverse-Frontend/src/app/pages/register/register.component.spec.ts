import { HttpClientModule } from '@angular/common/http';
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';

import { RegisterComponent } from './register.component';

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [
        RouterTestingModule,
        FormsModule,
        ReactiveFormsModule,
        HttpClientModule
      ],
      declarations: [ RegisterComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  
  it('CHECK REGISTER GROUP ELEMENT COUNT', () => {
    const formElement = fixture.debugElement.nativeElement.querySelector('#registerForm');
    const inputElements = formElement.querySelectorAll('input');
    expect(inputElements.length).toEqual(3);
  });

  it('CHECK INITIAL FORM VALUES FOR REGISTER FORM GROUP', () => {
    const registerFormGroup = component.registerForm;
    const registerFormValues = {
      email: '',
      password: '',
      confirmPassword: '',
      role : 'User'
    }
    expect(registerFormGroup.value).toEqual(registerFormValues);
  });

  it('CHECK EMAIL VALUE BEFORE ENTERING SOME VALUE AND VALIDATION', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                    .querySelector('#registerForm').querySelectorAll('input')[0];
    const emailValueFromGroup = component.registerForm.get('email');
    expect(registerFormUserElement.value).toEqual(emailValueFromGroup?.value);
    expect(emailValueFromGroup?.errors).not.toBeNull();
    expect(emailValueFromGroup?.errors?.['required']).toBeTruthy();
  });

  it('CHECK PASSWORD VALUE BEFORE ENTERING SOME VALUE AND VALIDATION', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                    .querySelector('#registerForm').querySelectorAll('input')[1];
    const passwordValueFromGroup = component.registerForm.get('password');
    expect(registerFormUserElement.value).toEqual(passwordValueFromGroup?.value);
    expect(passwordValueFromGroup?.errors).not.toBeNull();
    expect(passwordValueFromGroup?.errors?.['required']).toBeTruthy();
  });

  it('CHECK CONFIRM PASSWORD VALUE BEFORE ENTERING SOME VALUE AND VALIDATION', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                    .querySelector('#registerForm').querySelectorAll('input')[2];
    const confirmPasswordValueFromGroup = component.registerForm.get('confirmPassword');
    expect(registerFormUserElement.value).toEqual(confirmPasswordValueFromGroup?.value);
    expect(confirmPasswordValueFromGroup?.errors).not.toBeNull();
    expect(confirmPasswordValueFromGroup?.errors?.['required']).toBeTruthy();
  });

  it('CHECK EMAIL VALUE AFTER ENTERING SOME VALUE AND VALIDATION', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                      .querySelector('#registerForm').querySelectorAll('input')[0];
    registerFormUserElement.value = 'sample@gmail.com';
    registerFormUserElement.dispatchEvent(new Event ('input')) ;
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const emailValueFromGroup = component.registerForm.get('email');
      expect (registerFormUserElement.value).toEqual(emailValueFromGroup?.value);
      expect (emailValueFromGroup?.errors).toBeNull();
    })
  });

  it('CHECK PASSWORD VALUE AFTER ENTERING SOME VALUE AND VALIDATION', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                      .querySelector('#registerForm').querySelectorAll('input')[1];
    registerFormUserElement.value = 'Sample@123';
    registerFormUserElement.dispatchEvent(new Event ('input')) ;
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const passwordValueFromGroup = component.registerForm.get('password');
      expect (registerFormUserElement.value).toEqual(passwordValueFromGroup?.value);
      expect (passwordValueFromGroup?.errors).toBeNull();
    })
  });

  it('CHECK CONFIRM PASSWORD VALUE AFTER ENTERING SOME VALUE AND VALIDATION', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                    .querySelector('#registerForm').querySelectorAll('input')[2];
    registerFormUserElement.value = 'Sample@123';
    registerFormUserElement.dispatchEvent(new Event ('input')) ;
    fixture.detectChanges();
    fixture.whenStable().then(() => {
      const confirmPasswordValueFromGroup = component.registerForm.get('confirmPassword');
      expect (registerFormUserElement.value).toEqual(confirmPasswordValueFromGroup?.value);
      expect (confirmPasswordValueFromGroup?.errors).toBeNull();
    })
  });

  it('CHECK REGISTER FORM IS VALID WHEN VALIDATIONS ARE FULFILLED', () => {
    const registerFormUserElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                    .querySelector('#registerForm').querySelectorAll('input')[0];
    const registerFormPasswordElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                        .querySelector('#registerForm').querySelectorAll('input')[1];
    const registerFormConfirmPasswordElement: HTMLInputElement = fixture.debugElement.nativeElement
                                                        .querySelector('#registerForm').querySelectorAll('input')[2];
    registerFormUserElement.value = 'clara@gmail.com';
    registerFormPasswordElement.value = 'Clara@123';
    registerFormConfirmPasswordElement.value = 'Clara@123';
    registerFormUserElement.dispatchEvent(new Event ('input'));
    registerFormPasswordElement.dispatchEvent(new Event ('input'));
    registerFormConfirmPasswordElement.dispatchEvent(new Event ('input'));
    const isRegisterFormValid = component.registerForm.valid;
    expect(registerFormPasswordElement.value).toEqual(registerFormConfirmPasswordElement.value);
    fixture.whenStable().then(() => {
      expect(isRegisterFormValid).toBeTruthy;
    })
  });

  it('CHECK BUTTON function doRegister', () => {
    spyOn(component, 'doRegister');
  
    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();
  
    fixture.whenStable().then(() => {
      expect(component.doRegister).toHaveBeenCalled();
    });
  });

});
