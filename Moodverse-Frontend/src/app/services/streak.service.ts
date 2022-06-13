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

  findId(){
    let email = sessionStorage.getItem("currentUser");
    return this.http.get(
      this.baseUrl + 'api/Auth/getUserId/' + email,
      this.privateHttpHeaders
    );
  }

  findStreakId(){
    let email = sessionStorage.getItem("currentUser");
    return this.http.get(
      this.baseUrl + 'api/Auth/getUserIdStreak/' + email,
      this.privateHttpHeaders
    );
  }

  getStreakNumber(){
    this.findStreakId().subscribe((response:any) => {
      console.log("-------------");
      console.log(response);
      sessionStorage.setItem("StreakId", response);
      console.log(sessionStorage.getItem("StreakId"));
    })
    console.log(sessionStorage.getItem("StreakId"));
    return this.http.get(
      this.baseUrl + 'api/Streak/GetNumberOfDaysById/'+ sessionStorage.getItem("StreakId"),
      this.privateHttpHeaders
    )
  }

  createStreak(){
    this.findId().subscribe((response:any) => {
      sessionStorage.setItem("idUser", response);
    });
    console.log(sessionStorage.getItem("idUser"))
    return this.http.post(
      this.baseUrl + 'api/Streak/AddStreak/' + sessionStorage.getItem("idUser"),
      this.privateHttpHeaders
    )
  }

  updateStreak(){
    this.findStreakId().subscribe((response:any) => {
      sessionStorage.setItem("StreakId", response);
    })
    console.log(sessionStorage.getItem("StreakId"));
    return this.http.put(
      this.baseUrl + 'api/Streak/UpdateStreak/'+ sessionStorage.getItem("StreakId"),
      this.privateHttpHeaders
    )
  }

}