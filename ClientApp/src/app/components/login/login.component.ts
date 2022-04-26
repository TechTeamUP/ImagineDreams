import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  hide = true;
  constructor(private _UserService: UserService) { }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  logIn() {
    var body =
    {
      email: this.loginForm.value.email,
      password: this.loginForm.value.password
    }
    this._UserService.logIn(body.email, body.password,body).subscribe(data => {
      var closeBtn = document.getElementById("loginModal");
      closeBtn?.click();
    }, error =>{
      console.log(error)
    }
    ) 
  }

}
