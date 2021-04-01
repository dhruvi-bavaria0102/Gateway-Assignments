import { Component, OnInit } from '@angular/core';
import { CrudService } from '../crud.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  allUser:any;
  

  


  constructor(public crudService: CrudService) { 
    this.allUser = [];
  }
  ngOnInit() {
    this.getAllEmployee();
  }

  getAllEmployee() {
    //Get saved list of students
    this.crudService.getList().subscribe(response => {
      console.log(response);
      this.allUser = response;
      this.allUser.key();
    })
  }


  delete(item: { id: number; }) {
    //Delete item in Student data
    this.crudService.deleteItem(item.id).subscribe(Response => {
      //Update list after delete is successful
      this.getAllEmployee();
    });
  }
}






  
  





