import { Component, ViewChild, OnInit, ElementRef } from '@angular/core';
import { error } from 'console';
import { CompanyService } from '../company.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Table } from 'primeng/table';
import { MessageService, ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-company-data',
  templateUrl: './company-data.component.html',
  providers: [MessageService, ConfirmationService],
  styleUrls: []
})
export class CompanyDataComponent implements OnInit {
  public companyData: any;
  public removeCompany: any;
  public editCompany: any;
  comapnyForm!: FormGroup;
  comapnyEditForm!: FormGroup;
  @ViewChild('filter') filter!: ElementRef;
  loading: boolean = false;
  rows: any[] = [];
  visible: boolean = false;
  public companyList: any = [];

  constructor(
    private _companyService: CompanyService
  ) {


  }

  ngOnInit() {
    this.comapnyForm = new FormGroup({
      name: new FormControl('', Validators.required)
    });
    this.GetCompanyList();
  }

  public onSubmit() {
    debugger
    if (this.comapnyForm.valid) {
      const formData = this.comapnyForm.value;
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

  public GetCompanyList() {
    this.loading = true;
    this._companyService.GetCompanyList().subscribe({
      next: (res) => {
        this.companyList = res;

        this.loading = false;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }


  onGlobalFilter(table: Table, event: Event) {
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  clear(table: Table) {
    table.clear();
    this.filter.nativeElement.value = '';
  }
  EditDialog(company: any) {
    debugger
    this.visible = true;
    this.comapnyEditForm = new FormGroup({
      id: new FormControl(company.id),
      name: new FormControl(company.name, Validators.required),
      isActive: new FormControl(company.isActive)
    });

  }

  public edit() {
    debugger
    if (this.comapnyEditForm.valid) {
      const formData = this.comapnyEditForm.value;
      this._companyService.editCompany(formData).subscribe({
        next: (res) => {
          this.editCompany = res;
        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }

  public remove(id:number) {
    debugger
    
      this._companyService.removeCompany(id).subscribe({
        next: (res) => {
          this.removeCompany = res;
        },
        error: (err) => {
          console.log(err);
        }
      });
    

  }


}
