import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthService } from '../../../services/auth.service'
import { Router } from '@angular/router'
import { StorageService } from 'src/app/services/storage.service';
import { ToastrService } from 'ngx-toastr';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  loginForm = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl('', Validators.required),
  })
  constructor(
    private authService:AuthService,
    private router:Router,
    private storage:StorageService,
    private toastr: ToastrService
  ) { 
    
  }
  onSubmit(){
    const { userName,password } = this.loginForm.value
    this.authService.login(userName,password).subscribe({
      next: data =>{
        this.storage.saveUser(data)
        this.router.navigate(['/dashboard'])
      },
      error: err => {
        console.log('Error object:', err); // Log the entire error object to inspect its structure
        if (err && err.error && err.error.message) {
          this.toastr.error(err.error.message, 'Error');
        } else {
          this.toastr.error('An error occurred. Please try again later.', 'Error');
        }
      }
    });
    
  }

}
