import { Component, OnInit } from '@angular/core';
import { CrudService } from '../crud.service';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  allUser:any;

  


  constructor(public crudService: CrudService) { }
  ngOnInit(){
    this.getUser();
  }
  getUser(){
   this.crudService.getallUser().subscribe((response)=>{
  
      this.allUser = response;
  })
}
DeleteUser(user: { id: Int16Array; }){
  this.crudService.deleteUser(user).subscribe(()=>{
  this.getUser();
})
}


  
  

}



