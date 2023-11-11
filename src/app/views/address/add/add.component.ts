import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { AddressService,Iaddress } from '../../../services/address.service'
import { Router } from '@angular/router';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.scss']
})
export class AddComponent {
  addressForm = new FormGroup({
    UserId: new FormControl<number>(0, [Validators.required]) ,
    AddressLine1: new FormControl<string>('' , [Validators.required]),
    AddressLine2: new FormControl<string>('' , [Validators.required]),
    District: new FormControl<string>('' , [Validators.required]),
    City: new FormControl<string>('' , [Validators.required]),
    PostalCode: new FormControl<string>('', [Validators.required, Validators.minLength(5)])
  })

  constructor(private AddressService:AddressService,private router:Router){

  }
  onSubmit(){
    let formData: Iaddress = {
      UserId: this.addressForm.value?.UserId ?? 0,
      AddressLine1: this.addressForm.value.AddressLine1 ?? '',
    AddressLine2: this.addressForm.value.AddressLine2 ?? '',
    District: this.addressForm.value.District ?? '' ,
    City: this.addressForm.value.AddressLine2 ?? '' , 
    PostalCode: this.addressForm.value.PostalCode ?? '' ,
  };
    this.AddressService.add(formData).subscribe({
      next: data =>{
        console.log('API Response:', data);
        this.router.navigate(['/address/list'])
      },
      error: err =>{
        console.log('API Error:', err)
      }
    })
  }
}
