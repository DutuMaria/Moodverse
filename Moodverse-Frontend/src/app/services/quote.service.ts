import { HttpClient, HttpHeaders } from '@angular/common/http';
import { identifierName } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class QuoteService {
  private baseUrl: string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'text'
    }),
  };

  constructor(private http: HttpClient) {}

  getAllQuotes(){
    return this.http.get(
      this.baseUrl + 'api/DailyQuote/GetDailyQuotes',
      this.privateHttpHeaders
    )
  }

  getMessageById(id:any){
    return this.http.get(
      this.baseUrl + 'api/DailyQuote/GetMessageById/' + id,
      this.privateHttpHeaders
    )
  }

  addQuote(data: any) {
    console.log(data);
    return this.http.post(
      this.baseUrl + 'api/DailyQuote/AddDailyQuote',
      data,
      this.privateHttpHeaders,
    );
  }

  deleteQuote(id: any){
    return this.http.delete(
      this.baseUrl + 'api/DailyQuote/DeleteDailyQuote/' + id,
      this.privateHttpHeaders
    )
  }
}
