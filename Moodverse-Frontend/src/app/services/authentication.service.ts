import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})

export class AuthenticationService {
  private baseUrl: string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'text'
    }),
  };

  constructor(private http: HttpClient) {}

  login(data: any) {
    return this.http.post(
      this.baseUrl + 'api/Auth/login',
      data,
      this.privateHttpHeaders
    );
  }

  register(data: any) {
    console.log(this.baseUrl + 'api/Auth/register')
    console.log(data)
    return this.http.post(
      this.baseUrl + 'api/Auth/register',
      data,
      this.privateHttpHeaders,
    );
  }
}
