import { Component, OnInit } from '@angular/core';
import { error } from 'console';
import { CompanyService } from '../company.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';



@Component({
  selector: 'app-company-data',
  templateUrl: './company-data.component.html',
  styleUrls: []
})
export class CompanyDataComponent implements OnInit {
  public companyData: any;
  form!: FormGroup;
  constructor(
    private _companyService: CompanyService
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
      this._companyService.createCompanies(formData).subscribe({
        next: (res) => {
          this.companyData = res;
        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }



}
