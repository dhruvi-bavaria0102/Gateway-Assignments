import { Component, OnInit } from '@angular/core';
import { CrudService } from '../crud.service';
import { TouchSequence } from 'selenium-webdriver';


import { ActivatedRoute, Router } from '@angular/router';
import { Employee} from '../app.module';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  data: Employee;



  cofirmationString:string="new Employee has been add";
  isAdded:boolean=false;

  constructor(public crudService: CrudService,public router: Router) {
    this.data = new Employee();
    
  }
  
   
  submitForm() {
    this.crudService.createItem(this.data).subscribe((response) => {
      this.router.navigate(['list']);
    });
  }
  
  

  ngOnInit(): void {
  }

}
