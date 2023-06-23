import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { InvoiceDataComponent } from './invoice-data/invoice-data.component';

const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forChild([
    // { path: 'company', data: { breadcrumb: 'Button' }, loadChildren: () => import('./company-data/company-data.component').then(m => m.CompanyDataComponent) },
    
    { path: 'Invoice', component: InvoiceDataComponent  },
  ])],
  exports: [RouterModule]
})
export class InvoiceRoutingModule { }
