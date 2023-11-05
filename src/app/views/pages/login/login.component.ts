import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
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
    telephone: new FormControl(''),
    pin: new FormControl('')
  })
  constructor(
    private authService:AuthService,
    private router:Router,
    private storage:StorageService,
    private toastr: ToastrService
  ) { 
    
  }
  onSubmit(){
    const { telephone,pin } = this.loginForm.value
    this.authService.login(telephone,pin).subscribe({
      next: data =>{
        this.storage.saveUser(data)
        this.router.navigate(['/dashboard'])
      },
      error: err => {
        console.log('berkay',err.error.message)
        this.toastr.error (err.error.message, 'Error');
      }
    })
    //this.authService.login();
  }

}
