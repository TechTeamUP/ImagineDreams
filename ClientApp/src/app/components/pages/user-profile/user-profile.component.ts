import { Component, OnInit } from '@angular/core';
import { Chart } from 'chart.js';

@Component({
  selector: 'app-user-profile',
  templateUrl: './user-profile.component.html',
  styleUrls: ['./user-profile.component.css'],
})
export class UserProfileComponent implements OnInit {
  constructor() {}

  firstName: string = 'Daniel';
  lastName: string = 'Ortega';
  fullName: string = 'Daniel Ortega';
  nickname: string = 'Daniel_ort96';
  age: number = 23;
  city: string = 'Bucaramga';
  soldItems: number = 10;
  image: string =
    'https://cdn.pixabay.com/photo/2016/08/08/09/17/avatar-1577909_1280.png';

  ngOnInit(): void {}
    
}
