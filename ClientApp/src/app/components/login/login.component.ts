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
  constructor(private _UserService: UserService) {
    if (_UserService.userData) {
      var closeBtn = document.getElementById("loginModal");
      closeBtn?.click();
    }
  }

  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  logIn() {
    var email = this.loginForm.value.email;
    var password = this.loginForm.value.password;

    this._UserService.logIn(email, password).subscribe(response => {
      if (response.code === 200) {
        var closeBtn = document.getElementById("loginModal");
        closeBtn?.click();
        console.log(response);
      }
    }, error => {
      console.log(error)
    }
    )
  }

}
