import { HttpClient, HttpHeaders } from '@angular/common/http';
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
}
