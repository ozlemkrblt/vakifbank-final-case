import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { EMPTY, Observable, catchError } from 'rxjs';
import { ApiResponse,ApiRolesResponse , Role } from '../views/role/role-model';


@Injectable({
  providedIn: 'root'
})
export class RoleService {
  private AUTH_API = environment.AUTH_API;

  private httpOptions = environment.httpOptions;
  constructor(private http:HttpClient) { 
    
    
  }
  add(Id:any , Name :any ) : Observable<any>{
    /*console.log("in service : " + this.httpOptions)
    console.log(this.http)
      // Check if RoleId and RoleName are defined
  if (role.id === undefined || role.name === undefined && typeof role.id != 'number' && typeof role.name != 'string') {
    console.error("RoleId and RoleName must be defined.");
    return EMPTY; // or return an Observable with an appropriate error response
  }else{

    const body = JSON.stringify(role)
    console.log(" in service : " + body)
    console.log("in service type check." + typeof body)
    if(body == undefined ||body == null){
      console.log ("Bodyyyyy : " + typeof(body))
    }*/
     
      console.log('add role')
      console.log(this.AUTH_API) 
      const body = JSON.stringify({ Id, Name})
      console.log("body " + body);
      return this.http.post(this.AUTH_API + '/os/api/v1/role',body, this.httpOptions);
  
  
  }
  get() : Observable<ApiRolesResponse> {
    console.log("IN GET METHOD...")
    return this.http.get<ApiRolesResponse>(this.AUTH_API + '/os/api/v1/Role',this.httpOptions).pipe(
      catchError((error: any) => {
        console.error('Get method Error:', error);
        throw error; // Rethrow the error to propagate it to the component
      })
      );
  }
  getById(id:number): Observable<ApiResponse> {
    return this.http.get<ApiResponse>(`${this.AUTH_API}/os/api/v1/Role/${id}`,this.httpOptions)
  }
  update(id:number,params:any){
    return this.http.put(`${this.AUTH_API}/os/api/v1/Role/${id}`,params,this.httpOptions)
  }
}

