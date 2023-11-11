import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RoleService } from 'src/app/services/role.service'; 
import { ApiResponse, Role } from '../role-model';
import { EMPTY, catchError } from 'rxjs';

@Component({
  selector: 'app-role-detail',
  templateUrl: './role-detail.component.html',
  styleUrls: ['./role-detail.component.css']
})
export class RoleDetailComponent implements OnInit {
  roleId: number = 1; 
  role!: Role; 

  constructor(
    private route: ActivatedRoute,
    private roleService: RoleService
  ) { }

  ngOnInit() {
    if (this.roleId) {
      this.getRole();
    }
  }

  getRole() {
     if (this.roleId !== undefined) {
      this.roleService.getById(1).pipe(
        catchError((error) => {
          console.log("ssssssss");
          console.error('API Error:', error);
          return EMPTY; 
        })
      ).subscribe({
        next: (data) => {
          console.log('API Response:', data);
          this.role = data.responsesingle;
        },
        complete: () => {
          console.log('Subscription complete.');
        }
      });
    } else {
      console.error('Role ID is undefined');
    }
  }
  }

