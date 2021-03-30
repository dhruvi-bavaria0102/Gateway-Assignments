import { Component, OnInit } from '@angular/core';
import { CrudService } from '../crud.service';
import { TouchSequence } from 'selenium-webdriver';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  alluser: any;
  cofirmationString:string="new Employee has been add";
  isAdded:boolean=false;

  constructor(public crudService: CrudService) { }
  addUser(formObj: any){
    console.log(formObj)
    this.crudService.CreateUser(formObj).subscribe((response)=>{
      this.isAdded=true;
      this.getLatestUser();
   
       console.log("User has benn submiteed")
   })
  }
  getLatestUser(){
    this.crudService.getallUser().subscribe((response)=>
    this.alluser=response
    )}

  ngOnInit(): void {
  }

}
