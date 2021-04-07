import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from './Employee';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  baseURL: string = "http://localhost:3000/";

  constructor(private http: HttpClient) {}
  /*Get all companies data from json file and display it on list view. */
  public getJSON(): Observable<any> {
    return this.http.get(this.baseURL + 'employee');
  
  }
  /*Get one company data from company id. */
  public getEmployeeData(id: number): Observable<any> {
    return this.http.get(this.baseURL + 'employee?id=' + id);
  }
  /*Get one company data from company id. */
  public getData(id: number): Observable<any> {
    return this.http.get(this.baseURL + 'employee/' + id);
  }
  /*delete company data by company id from json file. */
  deleteData(id: number) {
    this.http.delete(this.baseURL + 'employee/' + id)
      .subscribe(data => console.log("delete successful for id=" + id));
  }
  /*Add new company data into json file */
  addEmployee(employee: Employee): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(employee);
    return this.http.post(this.baseURL + 'employee', body, { 'headers': headers })
  }
  /*Update company data by company id and save into json file. */
  updateData(id: number, employee: Employee): Observable<any> {
    const headers = { 'content-type': 'application/json' }
    const body = JSON.stringify(employee);
    return this.http.put(this.baseURL + 'employee/' + id.toString(), body, { 'headers': headers })
  }
}
