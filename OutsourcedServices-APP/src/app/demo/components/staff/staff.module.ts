import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { StaffRoutingModule } from './staff-routing.module';
import { StaffDataComponent } from './staff-data/staff-data.component';
import { FormsModule } from '@angular/forms';
import { ChipsModule } from "primeng/chips";
import { InputTextModule } from "primeng/inputtext";
import { Button, ButtonModule } from 'primeng/button';
import { BrowserModule } from '@angular/platform-browser';
import {  ReactiveFormsModule } from '@angular/forms';
import { InputMaskModule } from "primeng/inputmask";
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
    StaffDataComponent
  ],
  imports: [
    CommonModule,
    StaffRoutingModule,
    ButtonModule,
    FormsModule,
    ReactiveFormsModule,
    ChipsModule,
    InputTextModule,
    InputMaskModule,
    TableModule,
    ToggleButtonModule,
    RippleModule,
    MultiSelectModule,
    ProgressBarModule,
    ToastModule,
    SliderModule,
    RatingModule,
    DialogModule,
    DropdownModule
  ]
})
export class StaffModule { }
