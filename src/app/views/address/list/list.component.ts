import { Component, OnDestroy, OnInit } from '@angular/core';
import { AddressService } from 'src/app/services/address.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit,OnDestroy {
  data:any[] = []
  constructor(private addressService:AddressService){

  }
  ngOnInit(): void {
    this.load();  
  }

  load(){
    this.addressService.get().subscribe((response:any) => {
      this.data = response.data
    })
  }
  isDelete(){
    console.log('test');
  }
  ngOnDestroy(): void {
    
  }

}
