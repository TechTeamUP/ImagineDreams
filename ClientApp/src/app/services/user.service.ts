import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private myAppYrl = 'https://localhost:7200/service'

  constructor(private http: HttpClient) { }

  signUp(data: any): Observable<any> {
    return this.http.post(this.myAppYrl + "/user/sign_up", data)
  }
}
