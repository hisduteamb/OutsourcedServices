import { Component,ViewChild,ElementRef } from '@angular/core';
import { ServiceDetailService } from '../service-detail.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { Table } from 'primeng/table';
import { MessageService, ConfirmationService } from 'primeng/api';

@Component({

  selector: 'app-service-data',
  templateUrl: './service-data.component.html',
  providers: [MessageService, ConfirmationService],
  styleUrls: ['./service-data.component.scss']
})
export class ServiceDataComponent {

  public companyList: any;
  public companyServiceList: any;
  public companyService: any;
  @ViewChild('filter') filter!: ElementRef;
  loading: boolean = false;
  visible: boolean = false;
  form!: FormGroup;
  editCompanyServiceform!: FormGroup;
  constructor(
    private _serviceDetailService: ServiceDetailService,
    private formBuilder: FormBuilder
  ) {


  }

  ngOnInit() {
    this.form = this.formBuilder.group({
   
      Company_Id: ['', [Validators.required]],
      serviceName: ['', [Validators.required]],

    });

    this.GetCompanyList();
    this.getCompanyServiceList();
  }

  public onSubmit() {
    debugger
    if (this.form.valid) {
      const formData = this.form.value;
      this._serviceDetailService.createCompanyService(formData).subscribe({
        next: (res) => {
          this.companyService = res;
          

        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }

  public getCompanyServiceList()
  {
    debugger
    this.loading = true;
    this._serviceDetailService.getCompanyServiceList().subscribe({
      next: (res) => {
        
        this.companyServiceList = res;
        this.loading = false;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  public GetCompanyList()
  
  {
    debugger
    this._serviceDetailService.GetCompanyList().subscribe({
      next: (res)=>{
        debugger
        this.companyList =res;
        
      },
      error:(err)=>{
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
    this.editCompanyServiceform = new FormGroup({
      id: new FormControl(company.id),
      name: new FormControl(company.name, Validators.required),
      isActive: new FormControl(company.isActive)
    });

  }

  public edit() {
    debugger
    // if (this.comapnyEditForm.valid) {
    //   const formData = this.comapnyEditForm.value;
    //   this._companyService.editCompany(formData).subscribe({
    //     next: (res) => {
    //       this.editCompany = res;
    //     },
    //     error: (err) => {
    //       console.log(err);
    //     }
    //   });
    // }

  }

  public remove(id:number) {
    debugger
    
      // this._companyService.removeCompany(id).subscribe({
      //   next: (res) => {
      //     this.removeCompany = res;
      //   },
      //   error: (err) => {
      //     console.log(err);
      //   }
      // });
    

  }



}
