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
import {DropdownModule} from 'primeng/dropdown';


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
    DropdownModule
  ]
})
export class StaffModule { }
