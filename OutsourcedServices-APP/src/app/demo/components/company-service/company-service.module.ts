import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompanyServiceRoutingModule } from './company-service-routing.module';
import { ServiceDataComponent } from './service-data/service-data.component';
import { InputTextModule } from "primeng/inputtext";
import { Button, ButtonModule } from 'primeng/button';
import { BrowserModule } from '@angular/platform-browser';
import {  ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { ChipsModule } from "primeng/chips";
import {DropdownModule} from 'primeng/dropdown';

@NgModule({
  declarations: [
    ServiceDataComponent
  ],
  imports: [
    CommonModule,
    CompanyServiceRoutingModule,
    ChipsModule,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    DropdownModule
  ]
  
})
export class CompanyServiceModule { }
