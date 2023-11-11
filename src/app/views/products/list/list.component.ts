import { Component, OnDestroy, OnInit } from '@angular/core';
import { ProductService } from 'src/app/services/product.service';
import { Product } from '../product-model';
import { EMPTY, catchError } from 'rxjs';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit,OnDestroy {
  products: Product[] = [];

  constructor(private productService :ProductService){

  }
  ngOnInit(): void {
    this.load();  
  }

  load(){
    this.productService.get().pipe(

      catchError((error) => {
        console.log("ssssssss");
        console.error('API Error:', error);
        return EMPTY; // or handle the error appropriately
      })
    ).subscribe({
      next: (data) => {
        console.log('API Response:', data);
        this.products = data.response;
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
