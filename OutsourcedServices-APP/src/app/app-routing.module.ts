import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { NotfoundComponent } from './demo/components/notfound/notfound.component';
import { AppLayoutComponent } from "./layout/app.layout.component";

@NgModule({
    imports: [
        RouterModule.forRoot([
            {
                path: '', component: AppLayoutComponent,
                children: [
                    { path: 'c', loadChildren: () => import('./demo/components/company/company.module').then(m => m.CompanyModule) },
                    {path: 's',loadChildren:()=> import('./demo/components/staff/staff.module').then(m=>m.StaffModule)},
                    {path: 'cs',loadChildren:()=> import('./demo/components/company-service/company-service.module').then(m=>m.CompanyServiceModule)},
                    {path: 'in',loadChildren:()=> import('./demo/components/invoice/invoice.module').then(m=>m.InvoiceModule)}
                
                ]
            },
            
            { path: 'auth', loadChildren: () => import('./demo/components/auth/auth.module').then(m => m.AuthModule) },
            { path: 'landing', loadChildren: () => import('./demo/components/landing/landing.module').then(m => m.LandingModule) },
            { path: 'notfound', component: NotfoundComponent },
            { path: '**', redirectTo: '/notfound' },
        ], { scrollPositionRestoration: 'enabled', anchorScrolling: 'enabled', onSameUrlNavigation: 'reload' })
    ],
    exports: [RouterModule]
})
export class AppRoutingModule {
}
