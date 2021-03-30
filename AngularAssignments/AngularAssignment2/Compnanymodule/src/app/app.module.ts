import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import{FormsModule} from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import{RouterModule} from '@angular/router';

import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './home/home.component';
import { EmployeeComponent } from './employee/employee.component';
import { EditComponent } from './edit/edit.component';



@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    EmployeeComponent,
    EditComponent,
 
    
  ],
  imports: [
    BrowserModule,
   
    FormsModule,
    AppRoutingModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path:"",component:EmployeeComponent},
  
    {path:"home",component:HomeComponent},
    
    {path:"edit/:id",component:EditComponent}
      
      
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

export class Employee {  
    id?: number;  
    email?:string;
    name?: string;  
    totalEmployee?: number;  
    address?:string;
    employee_age?: number; 
    isCompanyActive?:boolean; 
    totalBranch?:number;
    branchId?:number;
    branchName?:string;
    
    
    
    
   
        
       
        
}  
