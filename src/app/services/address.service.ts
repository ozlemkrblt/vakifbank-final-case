import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs';

export interface Iaddress {
  UserId : number ,
  AddressLine1: string,
  AddressLine2: string,
  District: string,
  City: string,
  PostalCode: string,
}

@Injectable({
  providedIn: 'root'
})
export class AddressService {
  private AUTH_API = environment.AUTH_API;
  private httpOptions = environment.httpOptions;
  constructor(private http: HttpClient) {

  }
  add(params: Iaddress) {
    return this.http.post(this.AUTH_API + '/os/api/v1/Address/', params, this.httpOptions)
  }
  get() {
    return this.http.get(this.AUTH_API + '/os/api/v1/Address/', this.httpOptions).pipe(
      catchError((error: any) => {
        console.error('API Error:', error);
        throw error; // Rethrow the error to propagate it to the component
      })
      );
  }
  getById(id: number) {
    return this.http.get(`${this.AUTH_API}/os/api/v1/Address/${id}`, this.httpOptions)  .pipe(
      catchError((error: any) => {
        console.error('API Error:', error);
        throw error; // Rethrow the error to propagate it to the component
      })
      );
  }
  update(id: number, params: Iaddress) {
    return this.http.put(`${this.AUTH_API}/os/api/v1/Address/${id}`, params, this.httpOptions)
  }
}

