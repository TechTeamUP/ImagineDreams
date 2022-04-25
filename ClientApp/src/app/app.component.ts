import { Component } from '@angular/core';
import { InfoPageService } from './services/info-page.service';
import { ProductsService } from './services/products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
})
export class AppComponent {
  constructor(
    public infoServices: InfoPageService,
    public productsService: ProductsService
  ) {}
}
