import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { QuoteService } from 'src/app/services/quote.service';

@Component({
  selector: 'app-admin-page',
  templateUrl: './admin-page.component.html',
  styleUrls: ['./admin-page.component.scss']
})
export class AdminPageComponent implements OnInit {
  public addAmbienceForm!:FormGroup;
  public addBackgroundForm!:FormGroup;
  public addQuoteForm!:FormGroup;
  public quotesList = []

  constructor(private router:Router, private formBuilder:FormBuilder, private quoteService:QuoteService, private changeDetectorRef: ChangeDetectorRef) { }

  ngOnInit(): void {
    this.getAllQuotes();

    this.addAmbienceForm = this.formBuilder.group(
      {
        sound : [''],
        ambienceName : [''],
      }
    );
    this.addBackgroundForm = this.formBuilder.group(
      {
        image : [''],
        backgroundName : [''],
      }
    );
    this.addQuoteForm = this.formBuilder.group(
      {
        author : [''],
        message : ['']
      }
    );
  }

  getAllQuotes(){
    this.quoteService.getAllQuotes().subscribe((response:any) => {
      this.quotesList=response;
    } );
  }

  doLogout(){
    sessionStorage.removeItem("currentUser");
    sessionStorage.clear();
    this.router.navigate(['/index']);
  }

  addAmbience(){

  }

  addBackground(){

  }

  addQuote(){
    console.log(this.addQuoteForm);
    if (this.addQuoteForm.valid){
      this.quoteService.addQuote(this.addQuoteForm.value)
      .subscribe((response:any) => {
        alert("Daily Quote Added");
        this.addQuoteForm.reset();
      })
    }
  }

  onFileChange(event:any) {
  
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.addBackgroundForm.patchValue({
        fileSource: file
      });
    }
  }

  ngAfterViewChecked(): void {
    this.changeDetectorRef.detectChanges();
  }

  deleteQuote(id:any){
    this.quoteService.deleteQuote(id).subscribe((response:any) => {
      alert("Daily Quote Deleted");
      window.location.reload();
    });
  }
}
