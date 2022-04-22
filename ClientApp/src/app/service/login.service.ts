import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class signUp {

  private myAppYrl = 'https://localhost:7200/services'

  constructor(private http: HttpClient) { }

  signUp(data: any): Observable<any> {
    return this.http.post(this.myAppYrl + "/user", data)
  }

}
