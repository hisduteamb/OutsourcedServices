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
import { TableModule } from 'primeng/table';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { RippleModule } from 'primeng/ripple';
import { MultiSelectModule } from 'primeng/multiselect';
import { ProgressBarModule } from 'primeng/progressbar';
import { ToastModule } from 'primeng/toast';
import { SliderModule } from 'primeng/slider';
import { RatingModule } from 'primeng/rating';
import { DialogModule } from 'primeng/dialog';
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
    DropdownModule,
    TableModule,
    ToggleButtonModule,
    RippleModule,
    MultiSelectModule,
    ProgressBarModule,
    ToastModule,
    SliderModule,
    RatingModule,
    DialogModule

  ]
  
})
export class CompanyServiceModule { }
