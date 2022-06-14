import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AmbienceService } from 'src/app/services/ambience.service';
import { BackgroundService } from 'src/app/services/background.service';
import { QuoteService } from 'src/app/services/quote.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {
  public addAmbienceForm!: FormGroup;
  public addBackgroundForm!: FormGroup;
  public addQuoteForm!: FormGroup;
  public quotesList = [];
  public backgroundsList = [];
  public ambiencesList = [];
  public filePath!:any;
  public filePicture!:File;

  constructor(private router: Router, private formBuilder: FormBuilder, private quoteService: QuoteService, private changeDetectorRef: ChangeDetectorRef, private backgroundService: BackgroundService, private ambienceService: AmbienceService) { }

  ngOnInit(): void {
    this.getAllQuotes();
    this.getAllBackgrounds();
    this.getAllAmbiences();

    this.addAmbienceForm = this.formBuilder.group(
      {
        sound: [''],
        ambienceName: [''],
      }
    );
    this.addBackgroundForm = this.formBuilder.group(
      {
        image: [''],
        backgroundName: [''],
      }
    );
    this.addQuoteForm = this.formBuilder.group(
      {
        author: [''],
        message: ['']
      }
    );
  }

  getAllBackgrounds(){
    this.backgroundService.getAllBackgrounds().subscribe((response:any) => {
      this.backgroundsList = response;
    })
  }

  getAllQuotes() {
    this.quoteService.getAllQuotes().subscribe((response: any) => {
      this.quotesList = response;
    });
  }

  getAllAmbiences() {
    this.ambienceService.getAllAmbiences().subscribe((response: any) => {
      this.ambiencesList = response;
    });
  }

  doLogout() {
    sessionStorage.removeItem("currentUser");
    sessionStorage.clear();
    this.router.navigate(['/index']);
  }

  addAmbience() {
    if (this.addAmbienceForm.valid) {
      this.ambienceService.addAmbience(this.addAmbienceForm.value)
        .subscribe((response: any) => {
          alert("Ambience Added");
          this.addAmbienceForm.reset();
          window.location.reload();
        })
    }
  }

  addBackground() {
    if (this.addBackgroundForm.valid) {
      this.backgroundService.addBackground(this.addBackgroundForm.value)
        .subscribe((response: any) => {
          alert("Background Added");
          this.addBackgroundForm.reset();
          window.location.reload();
        })
    }
  }

  addQuote() {
    console.log(this.addQuoteForm);
    if (this.addQuoteForm.valid) {
      this.quoteService.addQuote(this.addQuoteForm.value)
        .subscribe((response: any) => {
          alert("Daily Quote Added");
          this.addQuoteForm.reset();
          window.location.reload();
        })
    }
  }

  onUploadBackground(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file.name);

      this.addBackgroundForm.patchValue({
        'image': file.name
      });
    }
  }

  onUploadAmbience(event: any) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      console.log(file.name);

      this.addAmbienceForm.patchValue({
        'sound': file.name
      });
    }
  }

  ngAfterViewChecked(): void {
    this.changeDetectorRef.detectChanges();
  }

  deleteQuote(id: any) {
    this.quoteService.deleteQuote(id).subscribe((response: any) => {
      alert("Daily Quote Deleted");
      window.location.reload();
    });
  }

  deleteBackground(id: any) {
    this.backgroundService.deleteBackground(id).subscribe((response: any) => {
      alert("Background Deleted");
      window.location.reload();
    });
  }

  deleteAmbience(id: any) {
    this.ambienceService.deleteAmbience(id).subscribe((response: any) => {
      alert("Ambience Deleted");
      window.location.reload();
    });
  }
}
