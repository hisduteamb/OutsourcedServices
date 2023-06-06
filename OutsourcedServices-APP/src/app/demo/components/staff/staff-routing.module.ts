import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { StaffDataComponent } from './staff-data/staff-data.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    // { path: 'company', data: { breadcrumb: 'Button' }, loadChildren: () => import('./company-data/company-data.component').then(m => m.CompanyDataComponent) },
    
    { path: 'Staff', component: StaffDataComponent  },
  ])],
  exports: [RouterModule]
})
export class StaffRoutingModule { }
