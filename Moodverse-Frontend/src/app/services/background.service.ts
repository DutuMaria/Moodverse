import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BackgroundService {
  private baseUrl:string = environment.baseUrl;
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: 'Bearer ' +  localStorage.getItem('token')
    })
  };
  constructor(private http:HttpClient) { }

  getAllBackgrounds(){
    return this.http.get(this.baseUrl + 'api/Background/GetBackgrounds', this.privateHttpHeaders);
  }
}
