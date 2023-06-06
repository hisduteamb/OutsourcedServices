import { Injectable } from '@angular/core';
import { Config } from 'src/app/_helpers/config.class';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  constructor(
    private http: HttpClient,

  ) { }

  public createCompanies(obj: any) {
    return this.http.post(`${Config.getControllerUrl("Company", "Create")}`, obj);
  }

}
