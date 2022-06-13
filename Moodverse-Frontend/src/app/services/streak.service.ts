import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class StreakService {
  private baseUrl: string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'text'
    }),
  };

  constructor(private http: HttpClient) { }

  /*
  findId(){
    let email = sessionStorage.getItem("currentUser");
    return this.http.get(
      this.baseUrl + 'api/Auth/getUserId/' + email,
      this.privateHttpHeaders
    );
  }*/

  findStreakId(){
    let email = sessionStorage.getItem("currentUser");
    return this.http.get(
      this.baseUrl + 'api/Auth/getUserIdStreak/' + email,
      this.privateHttpHeaders
    );
  }

  getStreakNumber(){
    return this.http.get(
      this.baseUrl + 'api/Streak/GetNumberOfDaysById/'+ this.findStreakId(),
      this.privateHttpHeaders
    )
  }

  createStreak(){
    return this.http.post(
      this.baseUrl + 'api/Streak/AddStreak',
      this.privateHttpHeaders
    )
  }

  updateStreak(){
    return this.http.put(
      this.baseUrl + 'api/Streak/UpdateStreak/'+ this.findStreakId(),
      this.privateHttpHeaders
    )
  }

}