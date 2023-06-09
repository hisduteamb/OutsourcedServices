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
  public getStaffList()
  {
    
    return this.http.get(`${Config.getControllerUrl("Staff", "GetStaff")}`
    );
  }
  public editStaff(obj: any) {
    return this.http.post(`${Config.getControllerUrl("Staff", "UpdateStaff")}`, obj);
  }

  public removeStaff(id: number) {
    
    return this.http.delete(`${Config.getControllerUrl("Staff", "DeleteStaff")}/${id}`);
  }
  public GetCompanyList()
  {
    debugger
    return this.http.get(`${Config.getControllerUrl("Root", "GetCompanies")}`
    );
  }
  public getDesignations()
  {
    
    return this.http.get(`${Config.getControllerUrl("Root", "GetDesignation")}`
    );
  }


  public getDivisions(Code: string)
  {
    
    return this.http.get(`${Config.getControllerUrl("Root", "GetDivision")}/${Code}`
    );
  }
  public GetDistricts(Code: string)
  {
    
    return this.http.get(`${Config.getControllerUrl("Root", "GetDistrict")}/${Code}`
    );
  }
  public GetTehsils(Code: string)
  {
    
    return this.http.get(`${Config.getControllerUrl("Root", "GetTehsil")}/${Code}`
    );
  }

  public GetHealthFacilitys(Code: string)
  {
    
    return this.http.get(`${Config.getControllerUrl("Root", "healthfacility")}/${Code}`
    );
  }

}
