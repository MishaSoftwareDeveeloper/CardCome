import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserModel } from '../Models/UserModel';
import { catchError, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  private httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json',
    })
  }
  constructor(private http:HttpClient) { }

  getAll(){
    return this.http.get(`api/user`,this.httpOptions).pipe(
      catchError((error:any) => {
        return throwError(()=> new Error(error));
      })
    )
  }

  add(userModel:UserModel){
    return this.http.post(`api/user`,userModel,this.httpOptions).pipe(
      catchError((error:any) => {
        return throwError(()=> new Error(error));
      })
    )
  }
  update(userModel:UserModel){
    return this.http.put(`api/user`,userModel,this.httpOptions).pipe(
      catchError((error:any) => {
        return throwError(()=> new Error(error));
      })
    )
  }
  delete(passport:string){
    return this.http.delete(`api/user/${passport}`,this.httpOptions).pipe(
      catchError((error:any) => {
        return throwError(()=> new Error(error));
      })
    )
  }
}
