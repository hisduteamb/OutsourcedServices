import { Injectable } from '@angular/core';
import { Config } from 'src/app/_helpers/config.class';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ServiceDetailService {

  constructor(
    private http: HttpClient,

  ) { }

  public createCompanyService(obj: any) {
    return this.http.post(`${Config.getControllerUrl("CompanyService", "Create")}`, obj);
  }

  public GetCompanyList()
  {
    debugger
    return this.http.get(`${Config.getControllerUrl("Root", "GetCompanies")}`
    );
  }

  public getCompanyServiceList()
  {
    debugger
    return this.http.get(`${Config.getControllerUrl("CompanyService", "GetCompanyService")}`
    );
  }
}
