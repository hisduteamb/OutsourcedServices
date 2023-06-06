import { Component } from '@angular/core';
import { ServiceDetailService } from '../service-detail.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-service-data',
  templateUrl: './service-data.component.html',
  styleUrls: ['./service-data.component.scss']
})
export class ServiceDataComponent {

  public companyData: any;
  form!: FormGroup;
  constructor(
    private _serviceDetailService: ServiceDetailService
  ) {


  }

  ngOnInit() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required)
    });
  }

  public onSubmit() {
    debugger
    if (this.form.valid) {
      const formData = this.form.value;
      // this._serviceDetailService.createCompanies(formData).subscribe({
      //   next: (res) => {
      //     this.companyData = res;
      //   },
      //   error: (err) => {
      //     console.log(err);
      //   }
      // });
    }

  }


}
