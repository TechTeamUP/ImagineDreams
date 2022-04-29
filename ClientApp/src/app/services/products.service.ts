import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Products } from '../interfaces/product.interface';

@Injectable({
  providedIn: 'root',
})
export class ProductsService {
  load = true;
  products: Products[] = [];
  filteredProducts: Products[] = [];
  filteredProductsByUsers: Products[] = [];

  constructor(private http: HttpClient) {
    this.loadProducts();
  }

  private loadProducts() {
    return new Promise<void>((resolve, reject) => {
      this.http
        .get(
          'https://imaginedreams-2d4e7-default-rtdb.firebaseio.com/products.json'
        )
        .subscribe((resp: any) => {
          this.products = resp;
          this.load = false;
          resolve();
        });
    });
  }

  getProduct(id: string) {
    return this.http.get(
      `https://imaginedreams-2d4e7-default-rtdb.firebaseio.com/products_id/${id}.json`
    );
  }

  searchProduct(term: string) {
    if (this.products.length === 0) {
      this.loadProducts().then(() => {
        this.filterProducts(term);
      });
    } else {
      this.filterProducts(term);
    }
  }

  private filterProducts(term: string) {
    this.filteredProducts = [];
    term = term.toLocaleLowerCase();
    console.log("test: ",this.filteredProducts)
    this.products.forEach((prod) => {
      // const authorLower = prod.author.toLocaleLowerCase();
      if (prod.category.indexOf(term) >= 0) {
        console.log("ola");
        this.filteredProducts.push(prod);
        
      }
    });
  }

  private filterProductsByUser(user: string){
    this.filteredProductsByUsers = [];
    this.products.forEach((prod) => {
      if (prod.author === user) {
        this.filteredProductsByUsers.push(prod);
      }
    });
  }
}
