import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListComponent } from './list/list.component';
import { ButtonModule, CardModule, FormModule, GridModule, TableModule } from '@coreui/angular';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { RolesRoutingModule } from './role-routing.module';
import { AddComponent } from './add/add.component';
import { RoleDetailComponent } from './role-detail/role-detail.component';
import { RoleService } from 'src/app/services/role.service';
import { IconModule } from '@coreui/icons-angular';
@NgModule({
  declarations: [
    ListComponent,
    AddComponent,
    RoleDetailComponent
  ],
  imports: [
    CommonModule,
    CardModule,
    TableModule,
    HttpClientModule,
    ButtonModule,
    FormModule,
    ReactiveFormsModule,
    RolesRoutingModule,
    GridModule,
    IconModule,

  ],
  providers :[
    RoleService
  ]
})
export class RoleModule { }
