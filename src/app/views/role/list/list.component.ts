import { Component, OnDestroy, OnInit } from '@angular/core';
import { EMPTY, catchError, first } from 'rxjs';
import { RoleService } from 'src/app/services/role.service';
import { ApiRolesResponse, Role } from '../role-model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit,OnDestroy {
  roles : Role[] = [];
  constructor(private roleService:RoleService){

  }
  ngOnInit(): void {
    this.load();  
  }

  load(){
    this.roleService.get().pipe(

      catchError((error) => {
        console.log("ssssssss");
        console.error('API Error:', error);
        return EMPTY; // or handle the error appropriately
      })
    ).subscribe({
      next: (data) => {
        console.log('API Response:', data);
        this.roles = data.response;
      },
      complete: () => {
        console.log('Subscription complete.');
      }
    });
  
  }
  isDelete(){
    console.log('test');
  }
  ngOnDestroy(): void {
    
  }

}
