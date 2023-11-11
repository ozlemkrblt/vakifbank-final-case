import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { RoleService } from '../../../services/role.service'
import { Router } from '@angular/router';
import { ApiResponse, Role } from '../role-model';


@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {
  roleForm = new FormGroup({
    Id: new FormControl('', [Validators.required,Validators.min(0)]),
    Name: new FormControl('', Validators.required),
})

  toastr: any;

  constructor(private roleService:RoleService,private router:Router){

  }
  onSubmit(){
    if (this.roleForm.valid) {
      const { Id, Name } = this.roleForm.value; // Ensure the casing matches your form controls
      console.log(Id, typeof Id);
      console.log(Name, typeof Name);
    
      if (Id != undefined) {
        console.log(Id + typeof Id + typeof Name + Name);
      this.roleService.add(Id , Name).subscribe({
        next: data => {
          console.log(data);
          this.router.navigate(['/login']);
        },
        error: err => {
          if (err && err.message) {
            console.log('API Error:', err.message);
          } else {
            console.log('An unexpected error occurred:', err);
          }
        }
      });
    }
    } else {
      this.toastr.error('Invalid form submission. Please check your input.', 'Error');
    }
  }
}
