import { Component, OnInit } from '@angular/core';
import {  FormControl, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service'
import { Router } from '@angular/router'
import { StorageService } from 'src/app/services/storage.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent{
  signupForm = new FormGroup({
      Name: new FormControl('', Validators.required),
       LastName: new FormControl('', Validators.required),
      userName: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(6)]),
      repeatPassword: new FormControl('', Validators.required),
      roleId: new FormControl('', [Validators.required,Validators.min(0)]),
  })
  constructor(    private authService: AuthService,
    private router: Router,
    private storage: StorageService,
    private toastr: ToastrService) {

  }

  onSubmit() {
    if (this.signupForm.valid) {
      const { Name ,LastName, userName, email, password, repeatPassword,roleId } = this.signupForm.value;
      if (password !== repeatPassword) {
        this.toastr.error('Passwords do not match.', 'Error');
        return;
      }

      this.authService.register(Name ,LastName,email, userName,  password , roleId).subscribe({
        next: data => {
          this.storage.saveUser(data);
          this.router.navigate(['/login']);
        },
        error: err => {
          console.log('Error:', err);
          this.toastr.error(err.error.message, 'Error');
        }
      });
    } else {
      this.toastr.error('Invalid form submission. Please check your input.', 'Error');
    }
  }




}
