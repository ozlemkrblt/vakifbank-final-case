import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StorageService } from './storage.service';
const AUTH_API = 'http://localhost:5000/api/';
const httpOptions = {
  headers : new HttpHeaders({'Content-Type':'application/json'})
}

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(
    private http: HttpClient,
    private storage:StorageService
  ) { }

  register(){
    console.log('register')
  }

  login(telephone:any,pin:any):Observable<any>{
    return this.http.post(AUTH_API+'auth/login/sms',{
      telephone,
      pin
    },httpOptions);
  }
  logOut(){
    this.storage.clean();
    window.location.href = '/#/login'
  }

  isLoggin(){
    let user = this.storage.getUser();
    if(user){
      return true
    }else{
      return false
    }
  }
  fetchExample():Observable<any>{
    return this.http.get(AUTH_API+'health',httpOptions);
  }
}