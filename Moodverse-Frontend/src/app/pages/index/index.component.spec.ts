import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';

import { IndexComponent } from './index.component';

describe('IndexComponent', () => {
  let component: IndexComponent;
  let fixture: ComponentFixture<IndexComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IndexComponent],
      imports: [
        HttpClientModule,
        RouterTestingModule,
      ]
    })
      .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(IndexComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('CHECK BUTTON function doLogout', () => {
    spyOn(component, 'doLogout');

    let button = fixture.debugElement.nativeElement.querySelectorAll('button')[3];
    button.click();

    fixture.whenStable().then(() => {
      expect(component.doLogout).toHaveBeenCalled();
    });
  });

  it('CHECK BUTTON function backgroundsFunction', () => {
    spyOn(component, 'backgroundsFunction');

    let button = fixture.debugElement.nativeElement.querySelectorAll('button')[4];
    button.click();

    fixture.whenStable().then(() => {
      expect(component.backgroundsFunction).toHaveBeenCalled();
    });
  });

  it('CHECK BUTTON function ambiencesFunction', () => {
    spyOn(component, 'ambiencesFunction');

    let button = fixture.debugElement.nativeElement.querySelectorAll('button')[5];
    button.click();

    fixture.whenStable().then(() => {
      expect(component.ambiencesFunction).toHaveBeenCalled();
    });
  });

  it('CHECK BUTTON function ballFunction', () => {
    spyOn(component, 'ballFunction');

    let button = fixture.debugElement.nativeElement.querySelectorAll('button')[6];
    button.click();

    fixture.whenStable().then(() => {
      expect(component.ballFunction).toHaveBeenCalled();
    });
  });

  // it('CHECK BUTTON function quotesFunction', () => {
  //   spyOn(component, 'quotesFunction');

  //   let button = fixture.debugElement.nativeElement.querySelectorAll('button')[7];
  //   button.click();

  //   fixture.whenStable().then(() => {
  //     expect(component.quotesFunction).toHaveBeenCalled();
  //   });
  // });

  // it('CHECK BUTTON function todolistsFunction', () => {
  //   spyOn(component, 'todolistsFunction');

  //   let button = fixture.debugElement.nativeElement.querySelectorAll('button')[8];
  //   button.click();

  //   fixture.whenStable().then(() => {
  //     expect(component.todolistsFunction).toHaveBeenCalled();
  //   });
  // });

  // it('CHECK BUTTON function moodTrackerFunction', () => {
  //   spyOn(component, 'moodTrackerFunction');

  //   let button = fixture.debugElement.nativeElement.querySelectorAll('button')[9];
  //   button.click();

  //   fixture.whenStable().then(() => {
  //     expect(component.moodTrackerFunction).toHaveBeenCalled();
  //   });
  // });

});
