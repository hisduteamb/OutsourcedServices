import { Component,ViewChild, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormArray } from '@angular/forms';
import { MessageService, ConfirmationService } from 'primeng/api';
import { StaffService } from '../../staff/staff.service';
import { InvoiceService } from '../invoice.service';

@Component({
  selector: 'app-invoice-data',
  templateUrl: './invoice-data.component.html',
  providers: [MessageService, ConfirmationService],
  styleUrls: ['./invoice-data.component.scss']
})
export class InvoiceDataComponent {

  public invoice: any;
  public editInvoice: any;
  public removeInvoice: any;
  public invoicelist: any;
  public designationData: any;
  invoiceform!: FormGroup;
  invoiceEditform!: FormGroup;
  invoiceDetail!: FormArray;
  @ViewChild('filter') filter!: ElementRef;
  selectedValue: any;
  public designations: any = [];
  public companyList: any=[];
  public divisions: any = [];
  public districts: any = [];
  public tehsils: any = [];
  public healthFacility: any = [];
  visible: boolean = false;
  loading: boolean = false;
  public Code: string = '0';

   // ];
   constructor(
    private _staffService: StaffService,
    private _invoiceService: InvoiceService,
    private formBuilder: FormBuilder
  ) {
  }
  
  ngOnInit() {
    this.invoiceform = this.formBuilder.group({
      companyId: ['', Validators.required],
      outsourceServiceId: ['', Validators.required],
      currentOfficerId: ['', Validators.required],
      trackingNumber: ['', Validators.required],
      receiveDatetime: ['', Validators.required],
      amount: ['', Validators.required],
      comments: ['', Validators.required],
      invoiceDetail: this.formBuilder.array([])
    });
    this.invoiceDetail = this.invoiceform.get('invoiceDetail') as FormArray;
    this.addInvoiceDetails(); // Add initial invoice detail form group
    this.GetCompanyList();
    

  }

  public onSubmit() {
    debugger
    if (this.invoiceform.valid) {
      const formData = this.invoiceform.value;
      this._invoiceService.createInvoice(formData).subscribe({
        next: (res) => {
          this.invoice = res;
         
        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }

  
  public addInvoiceDetails() {
    const invoiceDetailFormGroup = this.formBuilder.group({
      itemId: ['', Validators.required],
      quantity: ['', Validators.required],
      attendanceInDays: ['', Validators.required]
    });
    this.invoiceDetail.push(invoiceDetailFormGroup);
  }

  deleteInvoiceDetails(index: number) {
    this.invoiceDetail.removeAt(index);
  }

  public GetCompanyList()
  {
    
    this._staffService.GetCompanyList().subscribe({
      next: (res)=>{
        
        this.companyList =res;
        debugger
        
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }



}
