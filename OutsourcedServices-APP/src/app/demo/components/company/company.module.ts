import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ChipsModule } from "primeng/chips";
import { CompanyRoutingModule } from './company-routing.module';
import { CompanyDataComponent } from './company-data/company-data.component';
import { InputTextModule } from "primeng/inputtext";
import { Button, ButtonModule } from 'primeng/button';
import {  ReactiveFormsModule } from '@angular/forms';
import { TableModule } from 'primeng/table';
import { ToggleButtonModule } from 'primeng/togglebutton';
import { RippleModule } from 'primeng/ripple';
import { MultiSelectModule } from 'primeng/multiselect';
import { DropdownModule } from 'primeng/dropdown';
import { ProgressBarModule } from 'primeng/progressbar';
import { ToastModule } from 'primeng/toast';
import { SliderModule } from 'primeng/slider';
import { RatingModule } from 'primeng/rating';
import { DialogModule } from 'primeng/dialog';


@NgModule({
  declarations: [
    CompanyDataComponent
  ],
  imports: [
    CommonModule,
    InputTextModule,
    ChipsModule,
    CompanyRoutingModule,
    ButtonModule,
    FormsModule,
    TableModule,
    ToggleButtonModule,
    RippleModule,
    DropdownModule,
    MultiSelectModule,
    ProgressBarModule,
    ToastModule,
    DialogModule,
    SliderModule,
    RatingModule,
    ReactiveFormsModule
  ]
})
export class CompanyModule { }
