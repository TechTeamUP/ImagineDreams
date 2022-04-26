import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { UserService } from 'src/app/services/user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignUpComponent implements OnInit {
  hide = true;
  constructor(private _UserService: UserService) { }

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

    this._UserService.signUp(body).subscribe(data => {
      var closeBtn = document.getElementById("signUpModal");
      closeBtn?.click();
      
    }, error => {
      console.log(error)
    }
    )
  }

}
