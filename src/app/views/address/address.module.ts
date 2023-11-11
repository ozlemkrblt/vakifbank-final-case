import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './add/add.component';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { ButtonModule, CardModule, FormModule, TableModule } from '@coreui/angular';
import { AddressRoutingModule } from './address-routing.module';
import { ListComponent } from './list/list.component';



@NgModule({
  declarations: [
    AddComponent,
    ListComponent
  ],
  imports: [
    AddressRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ButtonModule,
    CardModule,
    FormModule,
    TableModule
  ]
})
export class AddressModule { }
