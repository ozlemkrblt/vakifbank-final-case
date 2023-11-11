import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';

interface Icard  {
  cardHolder: string;
  cardNumber: number;
  cvv: string;
  expenseLimit: number;
}

@Injectable({
  providedIn: 'root'
})
export class CardService {
  private AUTH_API = environment.AUTH_API;
  private httpOptions = environment.httpOptions;
  constructor(private http:HttpClient) { 

  }
  add(params:any){
    return this.http.post(this.AUTH_API + 'ads',params,this.httpOptions)
  }
  get(){
    return this.http.get(this.AUTH_API + 'ads',this.httpOptions)
  }
  getById(id:number){
    return this.http.get(`${this.AUTH_API}ads/detail/${id}`,this.httpOptions)
  }
  update(id:number,params:any){
    return this.http.put(`${this.AUTH_API}ads/${id}`,params,this.httpOptions)
  }
}

