import { Component } from '@angular/core';
import { StaffService } from '../staff.service';
import { FormGroup,FormBuilder, FormControl, Validators } from '@angular/forms';


@Component({
  selector: 'app-staff-data',
  templateUrl: './staff-data.component.html',
  styleUrls: ['./staff-data.component.scss']
})
export class StaffDataComponent {

  public staffData: any;
  public designationData: any;
  form!: FormGroup;
  public designations: any = [];
  public divisions: any = [];
  public filter: boolean = true;
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
    this.form = this.formBuilder.group({
      name: ['', Validators.required],
      mobileNumber: ['', [Validators.required, Validators.pattern(/^\d{3}-\d{3}-\d{4}$/)]],
      email: ['', [Validators.required, Validators.email]],
      designation: ['', Validators.required]
     
    });

    this.GetDesignations();
   
  }

  public onSubmit() {
    
    if (this.form.valid) {
      const formData = this.form.value;
      this._staffService.createStaff(formData).subscribe({
        next: (res) => {
          this.staffData = res;
        },
        error: (err) => {
          console.log(err);
        }
      });
    }

  }

  public GetDesignations()
  {
    
    this._staffService.getDesignations().subscribe({
      next: (res)=>{
        debugger
        this.designations= res;
        
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }

  public GetDivisions()
  {
    
    this._staffService.getDivisions().subscribe({
      next: (res)=>{
        debugger
        this.divisions= res;
        
      },
      error:(err)=>{
        console.log(err);
      }
    });
  }


}
