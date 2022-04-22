import { Component, OnInit } from '@angular/core';
import { signUp } from 'src/app/service/login.service';
import { FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {
  hide = true;
  constructor(private _signUp: signUp) {  }

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  ngOnInit(): void {
    //this.loginComponent()
  }

  // loginComponent() {
  //   this._LoginService.login().subscribe(data => {
  //     console.log(data);
  //   }, error => {
  //     console.log(error)
  //   }
  //   )
  // }
  onSubmit() {
    console.log(this.loginForm.value);
  }
}
