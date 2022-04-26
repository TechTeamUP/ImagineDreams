import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private signUpURL = 'https://localhost:7200/service'
  private logInURL = 'https://localhost:7200/service'

  constructor(private http: HttpClient) { }

  signUp(data: any): Observable<any> {
    return this.http.post(this.signUpURL + "/user/sign_up", data)
  }

  logIn(email:string, password:string, data: any)
  {
    return this.http.post(this.logInURL + `/user/log_in?mail=${email}&password=${password}`,data)
  }
}
