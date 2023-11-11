import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponent } from './add/add.component';
import { ListComponent } from './list/list.component';
//import { EditComponent } from './edit/edit.component';
import { ProductsRoutingModule } from './products-routing.module';
import { ButtonModule, CardModule, FormModule, TableModule } from '@coreui/angular';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';




@NgModule({
  declarations: [
    AddComponent,
    ListComponent
  ],
    imports: [
      CommonModule,
      ProductsRoutingModule,
      CardModule,
      TableModule,
      HttpClientModule,
      ButtonModule,
      FormModule,
      ReactiveFormsModule,
  ]
})
export class ProductsModule { }
