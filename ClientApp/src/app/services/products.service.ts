import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Products } from '../interfaces/product.interface';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  load= true;
  products: Products[] = [];

  constructor(private http: HttpClient) {
    this.loadProducts();
  }

  private loadProducts(){
    return new Promise<void>( (resolve, reject) => {
      this.http.get('https://imaginedreams-2d4e7-default-rtdb.firebaseio.com/products.json')
      .subscribe( (resp: any) => {
        this.products = resp;
        this.load = false;
        resolve();
      } )
    } )
  }
}
