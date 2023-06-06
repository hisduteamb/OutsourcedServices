import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';
import { ChipsModule } from "primeng/chips";

import { CompanyRoutingModule } from './company-routing.module';
import { CompanyDataComponent } from './company-data/company-data.component';
import { InputTextModule } from "primeng/inputtext";
import { Button, ButtonModule } from 'primeng/button';
import { BrowserModule } from '@angular/platform-browser';
import {  ReactiveFormsModule } from '@angular/forms';



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
    ReactiveFormsModule
  ]
})
export class CompanyModule { }
