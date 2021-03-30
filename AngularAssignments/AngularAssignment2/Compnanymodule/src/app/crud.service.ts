import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { Observable, ObservedValueOf, throwError } from 'rxjs';
import { Employee } from './app.module';


@Injectable({
  providedIn: 'root'
})
export class CrudService {

  base_path='http://localhost:3000/Users';

  constructor(private _http:HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  // Handle API errors
  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      console.error('An error occurred:', error.error.message);
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      console.error(
        `Backend returned code ${error.status}, ` +
        `body was: ${error.error}`);
    }
    // return an observable with a user-facing error message
    return throwError(
      'Something bad happened; please try again later.');
  };


  id: number | undefined;
  private headers=new Headers({'Content-Type':'application/json'});
  CreateUser(user: any)
  {
    return this._http.post("http://localhost:3000/Users",user);
  }
  getallUser()
  {
    return this._http.get("http://localhost:3000/Users");
  }
  deleteUser(user: { id: Int16Array; })
  {
    
    return this._http.delete("http://localhost:3000/Users/"+user.id);
    
  }
  updateItem(id: string, item: any): Observable<Employee> {
  
    return this._http
      .put<Employee>(this.base_path + '/' + id, JSON.stringify(item), this.httpOptions)
      
      
}
getItem(id:number): Observable<Employee> {
  return this._http
    .get<Employee>(this.base_path + '/' + id)
   
}
}
