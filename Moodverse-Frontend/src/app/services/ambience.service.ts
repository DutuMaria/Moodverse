import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AmbienceService {
  private baseUrl: string = environment.baseUrl;

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      'responseType': 'text'
    }),
  };

  constructor(private http: HttpClient) { }

  getAllAmbiences() {
    return this.http.get(this.baseUrl + 'api/Ambience/GetAmbiences', this.privateHttpHeaders);
  }

  addAmbience(data:any){
    return this.http.post(
      this.baseUrl + 'api/Ambience/AddAmbience',
      data,
      this.privateHttpHeaders
    );
  }

  deleteAmbience(id: any){
    return this.http.delete(
      this.baseUrl + 'api/Ambience/DeleteAmbience/' + id,
      this.privateHttpHeaders
    )
  }

}
