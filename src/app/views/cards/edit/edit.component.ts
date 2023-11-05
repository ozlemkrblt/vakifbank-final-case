import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { CardService } from 'src/app/services/card.service';
import {Observable} from 'rxjs';
import {map} from 'rxjs/operators';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.scss']
})
export class EditComponent implements OnInit {
  cardId!:number
  cardForm = new FormGroup({
    cardHolder: new FormControl(''),
    cardNumber: new FormControl(''),
    cvv: new FormControl(''),
    expenseLimit: new FormControl('')
  })
  constructor(
    private cardService:CardService,
    private router:Router,
    private route: ActivatedRoute
    ){
      const id: string = route.snapshot.params['id'];
      this.cardId = parseInt(id)
  }
  ngOnInit(): void { 
    this.load();
  }

  load(){
    console.log(this.cardId,'cardID');
    this.cardService.getById(this.cardId).subscribe((response:any) => {
      console.log(response.data.id)
      this.cardForm.controls['cardHolder'].setValue(response.data.cardHolder)
      this.cardForm.controls['cardNumber'].setValue(response.data.cardNumber)
      this.cardForm.controls['cvv'].setValue(response.data.cvv)
      this.cardForm.controls['expenseLimit'].setValue(response.data.expenseLimit)
      //this.data = response.data
    })
  }
  onSubmit(){
    this.cardService.update(this.cardId,this.cardForm.value).subscribe({
      next: data =>{
        console.log(data);
        //this.router.navigate(['/card/list'])
      },  
      error: err =>{
        console.log(err,'error')
      }
    })
  }
}
//activated route a bak çarş