import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { InfoPageService } from '../../services/info-page.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  constructor(
    public infoService: InfoPageService, 
    private route: Router
    ) {}

  ngOnInit(): void {}

  userLoggedIn: boolean = true;
  
  searchProduct(term: string) {
    console.log("test: ",term);
    if (term.length < 1) {
      return;
    }
    this.route.navigate(['/search', term]);
  }
}
