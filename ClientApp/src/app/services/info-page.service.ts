import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { InfoPage } from '../interfaces/info-page';


@Injectable({
  providedIn: 'root'
})
export class InfoPageService {

  info: InfoPage = {};
  cargada = false;
  team: any[] = [];

  constructor(private http: HttpClient) { 
    this.loadInfo();

  }

  private loadInfo() {
    this.http.get('assets/data/data-page.json')
      .subscribe((resp: InfoPage) => {
        this.cargada = true;
        this.info = resp;
      });
  }
}
