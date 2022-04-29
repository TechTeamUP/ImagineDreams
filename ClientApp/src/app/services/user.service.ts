import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Response } from '../models/Response';


const httpOption = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}
@Injectable({
  providedIn: 'root'
})
export class UserService {

  private ServiceURL: string = 'https://localhost:7200/service/user/login'

  private userSubject: BehaviorSubject<User>;

  public get userData(): User {
    return this.userSubject.value;
  }

  constructor(private _http: HttpClient) {
    this.userSubject = new BehaviorSubject<User>(JSON.parse(localStorage.getItem('User') || '{}'));
  }

  logIn(email: string, password: string): Observable<Response> {
    return this._http.post<Response>(this.ServiceURL, { email, password }, httpOption).pipe(
      map(res => {
        if (res.code === 200) {
          const user: User = res.data;
          localStorage.setItem('User', JSON.stringify(user));
          this.userSubject.next(user);
        }
        return res;
      })
    );
  }

  signUp(data: any): Observable<any> {
    return this._http.post(this.ServiceURL + "/user/sign_up", data)
  }

  logOut() {
    localStorage.removeItem('User');
    this.userSubject.next(null!);
  }

}
