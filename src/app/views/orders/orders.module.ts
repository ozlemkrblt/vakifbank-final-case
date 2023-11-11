import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddComponentComponent } from './add/add.component/add.component.component';
import { AddComponent } from './add/add/add.component';
import { EditComponent } from './edit/edit/edit.component';
import { ListComponent } from './list/list/list.component';



@NgModule({
  declarations: [
    AddComponentComponent,
    AddComponent,
    EditComponent,
    ListComponent
  ],
  imports: [
    CommonModule
  ]
})
export class OrdersModule { }
