import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { signUp } from 'src/app/service/login.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignUpComponent implements OnInit {
  hide = true;
  constructor(private _signUp: signUp) { }

  ngOnInit(): void {
  }

  signUpForm = new FormGroup({
    name: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
  });

  signUp() {
    var body = {
      fullname: this.signUpForm.value.name,
      email: this.signUpForm.value.email,
      password: this.signUpForm.value.password
    }

    this._signUp.signUp(body).subscribe(data => {
      var closeBtn = document.getElementById("signUpModal");
      closeBtn?.setAttribute('class', 'modal fade');
      closeBtn?.setAttribute('aria-hidden', 'true');
      closeBtn?.setAttribute('style', 'display: none');

    }, error => {
      console.log(error)
    }
    )
  }
}
