import { Injectable } from '@angular/core';
import { Config } from 'src/app/_helpers/config.class';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class InvoiceService {

  constructor(
    private http: HttpClient,
  ) { }
  
  public createInvoice(obj: any) {
    debugger
    return this.http.post(`${Config.getControllerUrl("Invoice", "Create")}`, obj);
  }
}
