import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, catchError, throwError } from 'rxjs';
import { StorageService } from './storage.service';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})

export class AuthService {
  private AUTH_API = environment.AUTH_API;
  private httpOptions = environment.httpOptions;

  constructor(
    private http: HttpClient,
    private storage: StorageService
  ) { }

  register(Name : any , LastName: any, email: any, userName: any, password: any , roleId : any ): Observable<any> {
    console.log('register')
    const body = JSON.stringify({ Name, LastName, userName, password , email, roleId})
    return this.http.post(this.AUTH_API + '/os/api/v1/user',body, this.httpOptions);
  }

  login(userName: any, password: any): Observable<any> {
    console.log(typeof(password));

    const body = JSON.stringify({ userName, password })

    return this.http.post(this.AUTH_API + "/os/api/v1/token",body, this.httpOptions)
    .pipe(
      catchError(error => {
        console.error('Error occurred:', error);
        return throwError(error); // Rethrow the error
      })
    );
  }
  logOut() {
    this.storage.clean();
    window.location.href = '/#/login'
  }

  isLoggin() {
    let user = this.storage.getUser();
    if (user) {
      return true
    } else {
      return false
    }
  }
  fetchExample(): Observable<any> {
    return this.http.get(this.AUTH_API + 'health', this.httpOptions);
  }

  }