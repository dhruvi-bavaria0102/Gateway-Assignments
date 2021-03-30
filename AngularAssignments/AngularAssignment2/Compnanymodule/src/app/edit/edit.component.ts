import { Component, OnInit } from '@angular/core';
import { CrudService } from '../crud.service';
import { EmployeeComponent } from '../employee/employee.component';
import { Employee } from '../app.module';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  submitted=false;
  id:any;
  public data:Employee;
    
  

  constructor(public crudService: CrudService,public route:Router,public activatedRoute: ActivatedRoute) 
  
  {
  this.data=new Employee();
  }
 
         
  
  ngOnInit() {
    this.id = this.activatedRoute.snapshot.params["id"];
    //get item details using id
    this.crudService. getItem(this.id).subscribe(response => {
      console.log(response);
      this.data = response;
    })
  }

  update() {
    //Update item by taking id and updated data object
    this.crudService.updateItem(this.id, this.data).subscribe(response => {
      this.route.navigate(['employee']);
    })
  }

}