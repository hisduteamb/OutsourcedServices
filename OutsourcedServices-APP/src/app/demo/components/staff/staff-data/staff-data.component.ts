import { Component,ViewChild ,ElementRef} from '@angular/core';
import { StaffService } from '../staff.service';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Table } from 'primeng/table';
import { MessageService, ConfirmationService } from 'primeng/api';


@Component({
  selector: 'app-staff-data',
  templateUrl: './staff-data.component.html',
  providers: [MessageService, ConfirmationService],
  styleUrls: ['./staff-data.component.scss']
})
export class StaffDataComponent {

  public staffData: any;
  public editStaff: any;
  public RemoveStaff: any;
  public stafflist: any;
  public designationData: any;
  staffform!: FormGroup;
  staffEditform!: FormGroup;
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

  public selectedFiltersModel: any = {
    division: { Name: 'Select Division', Code: '0' },
    district: { Name: 'Select District', Code: '0' },
    tehsil: { Name: 'Select Tehsil', Code: '0' }
  };
  // designations: any[] = [
  //   { label: 'Manager', value: 'manager' },
  //   { label: 'Developer', value: 'developer' },
  //   { label: 'Designer', value: 'designer' }
  // ];
  constructor(
    private _staffService: StaffService,
    private formBuilder: FormBuilder
  ) {


  }


  ngOnInit() {
    this.staffform = this.formBuilder.group({
   
      cnic: ['', [Validators.required]],
      name: ['', Validators.required],
      fatherName: ['', Validators.required],
      mobile: ['', [Validators.required ]],
      email: ['', [Validators.required, Validators.email]],
      Company_Id: ['', Validators.required],
      designation_Id: ['', Validators.required],
      division: ['', Validators.required],
      district: ['', Validators.required],
      tehsil: ['', Validators.required],
      HF_Id : ['', Validators.required]
      


    });
    this.selectedValue = this.staffform.get('selectedValue') as FormControl;
    this.getStaffList();
    this.GetDesignations();
    this.GetDivisions();
    this.GetDistricts();
    this.GetTehsils();
    this.GetHealthFacilitys();
    this.GetCompanyList();
    

  }

  public onSubmit() {
    debugger
    if (this.staffform.valid) {
      const formData = this.staffform.value;
      this._staffService.createStaff(formData).subscribe({
        next: (res) => {
          this.staffData = res;
          this.getStaffList();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }
  public GetCompanyList()
  {
    
    this._staffService.GetCompanyList().subscribe({
      next: (res)=>{
        
        this.companyList =res;
        
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }

  public getStaffList()
  {
    debugger
    this.loading = true;
    this._staffService.getStaffList().subscribe({
      next: (res) => {
        
        this.stafflist = res;
        this.loading = false;
      },
      error: (err) => {
        console.log(err);
      }
    });
  }


  public GetDesignations() {

    this._staffService.getDesignations().subscribe({
      next: (res) => {
        
        this.designations = res;

      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  public GetDivisions() {

    this._staffService.getDivisions(this.Code).subscribe({
      next: (res) => {

        this.divisions = res;
        if (this.divisions.length == 1) {
          this.selectedFiltersModel.division = this.divisions[0];
        }

      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  public GetDistricts() {

    this._staffService.GetDistricts(this.Code).subscribe({
      next: (res) => {
        
        this.districts = res;

        if (this.districts.length == 1) {
          this.selectedFiltersModel.district = this.districts[0];
        }

      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  public GetTehsils() {

    this._staffService.GetTehsils(this.Code).subscribe({
      next: (res) => {

        this.tehsils = res;
        if (this.tehsils.length == 1) {
          this.selectedFiltersModel.tehsil = this.tehsils[0];
        }

      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  public GetHealthFacilitys() {

    this._staffService.GetHealthFacilitys(this.Code).subscribe({
      next: (res) => {

        this.healthFacility = res;

      },
      error: (err) => {
        console.log(err);
      }
    });
  }

  onDropdownChange(event: any) {
    // Retrieve the selected value from the event

    this.selectedValue = event.value;

    console.log('Selected value:', this.selectedValue);
  }


  onDropdownLoadDistrict(code: any) {
    // Retrieve the selected value from the event
    
    // this.selectedValue = event.value;
    this._staffService.GetDistricts(code.value).subscribe((res: any) => {
      if (res) {
        debugger
        this.districts = res;
      }
    })
    this._staffService.GetTehsils(code.value).subscribe((res: any) => {
      if (res) {
        
        this.tehsils = res;
        this.healthFacility=[]
      }
    })
    // console.log('Selected value:', this.selectedValue);
  }

  onDropdownLoadtehsil(code: any) {
    // Retrieve the selected value from the event
    
    // this.selectedValue = event.value;
    this._staffService.GetTehsils(code.value).subscribe((res: any) => {
      if (res) {
        
        this.tehsils = res;
      }
    })
    // console.log('Selected value:', this.selectedValue);
  }

  onDropdownLoadHealthFacility(code: any) {
    // Retrieve the selected value from the event
    
    // this.selectedValue = event.value;
    this._staffService.GetHealthFacilitys(code.value).subscribe((res: any) => {
      if (res) {
        
        this.healthFacility = res;
      }
    })
    // console.log('Selected value:', this.selectedValue);
  }
  onGlobalFilter(table: Table, event: Event) {
    debugger
    table.filterGlobal((event.target as HTMLInputElement).value, 'contains');
  }

  clear(table: Table) {
    table.clear();
    this.filter.nativeElement.value = '';
  }


  EditDialog(staff: any) {
    debugger
    this.visible = true;
   
    this.staffEditform = this.formBuilder.group({
      id:[staff.id],
      cnic: [staff.cnic, [Validators.required]],
      name: [staff.name, Validators.required],
      fatherName: [staff.fatherName, Validators.required],
      mobile: [staff.mobile, [Validators.required ]],
      email: [staff.email, [Validators.required, Validators.email]],
      Company_Id: [staff.company_Id, Validators.required],
      designation_Id: [staff.designation_Id, Validators.required],
      division: [staff.division, Validators.required],
      district: [staff.district, Validators.required],
      tehsil: [staff.tehsil, Validators.required],
      HF_Id : [staff.hF_Id, Validators.required],
      healthFacilityName:[staff.healthFacilityName],
      CompanyName: [staff.companyName],
      isActive:(staff.isActive)
      


    });

  }

  public edit() {
    debugger
    if (this.staffEditform.valid) {
      const formData = this.staffEditform.value;
      this._staffService.editStaff(formData).subscribe({
        next: (res) => {
          this.editStaff = res;
          this.getStaffList();
        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }

  public remove(id:number) {
    debugger
    
      this._staffService.removeStaff(id).subscribe({
        next: (res) => {
          this.RemoveStaff = res;
          this.getStaffList();
        },
        error: (err) => {
          console.log(err);
        }
      });
    

  }


}
