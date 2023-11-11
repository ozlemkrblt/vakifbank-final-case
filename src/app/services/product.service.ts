import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { ApiResponse, Product } from '../views/products/product-model';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class ProductService {
  private AUTH_API = environment.AUTH_API;
  private httpOptions = environment.httpOptions;
  constructor(private http:HttpClient) { 

  }
  add(params:any){
    return this.http.post(this.AUTH_API + 'ads',params,this.httpOptions)
  }
  get() : Observable<ApiResponse>{
    console.log("in get method")
    return this.http.get<ApiResponse>(`${this.AUTH_API}/os/api/v1/Role`, this.httpOptions);
  }
  //getById(id:number){
  //  return this.http.get(`${this.AUTH_API}ads/detail/${id}`,this.httpOptions)
  //}
  //update(id:number,params:any){
  //  return this.http.put(`${this.AUTH_API}ads/${id}`,params,this.httpOptions)
  //}
}

