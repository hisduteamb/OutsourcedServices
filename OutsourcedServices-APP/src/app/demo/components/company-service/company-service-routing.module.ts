import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ServiceDataComponent } from './service-data/service-data.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    // { path: 'company', data: { breadcrumb: 'Button' }, loadChildren: () => import('./company-data/company-data.component').then(m => m.CompanyDataComponent) },
    
    { path: 'service', component: ServiceDataComponent },
  ])],
  exports: [RouterModule]
})
export class CompanyServiceRoutingModule { }
