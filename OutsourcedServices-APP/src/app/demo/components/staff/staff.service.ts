import { Injectable } from '@angular/core';
import { Config } from 'src/app/_helpers/config.class';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class StaffService {

  constructor(
    private http: HttpClient,

  ) { }

  public createStaff(obj: any) {
    return this.http.post(`${Config.getControllerUrl("Staff", "Create")}`, obj);
  }

  public getDesignations()
  {
    debugger
    return this.http.get(`${Config.getControllerUrl("Root", "GetDesignation")}`
    );
  }
  public getDivisions()
  {
    debugger
    return this.http.get(`${Config.getControllerUrl("Root", "GetDivision")}`
    );
  }

}
