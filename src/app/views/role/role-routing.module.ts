import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ListComponent } from './list/list.component';
import { AddComponent } from './add/add.component';
import { RoleDetailComponent } from './role-detail/role-detail.component';
//import { EditComponent } from './edit/edit.component';

const routes: Routes = [
  {
   path: 'list',
   component: ListComponent,
    data: {
      title: 'Role List'
    }
  },
  {
    path: 'add',
    component: AddComponent,
    data: {
      title: 'Role Add'
    }
  },
  {
    path: 'detail/:id',
    component: RoleDetailComponent,
    data: {
      title: 'Role Detail'
    }
  },
 // {
 //   path: 'edit/:id',
 //   component: EditComponent,
 //   data: {
 //     title: 'Card Edit'
 //   }
 // },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RolesRoutingModule {
}
