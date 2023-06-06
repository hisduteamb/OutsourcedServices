import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CompanyDataComponent } from './company-data/company-data.component';


const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    // { path: 'company', data: { breadcrumb: 'Button' }, loadChildren: () => import('./company-data/company-data.component').then(m => m.CompanyDataComponent) },
    
    { path: 'company', component: CompanyDataComponent },
  ])],
  exports: [RouterModule]
})
export class CompanyRoutingModule { }
