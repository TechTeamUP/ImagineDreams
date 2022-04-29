import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SalesService {

  private salesURL = "https://localhost:7200/service/sales/create"

  constructor(private http: HttpClient) { }

  sales(body: any) {
    return this.http.post(this.salesURL, body)
  }
}
