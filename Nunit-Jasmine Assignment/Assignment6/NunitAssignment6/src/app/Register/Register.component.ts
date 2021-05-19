import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class RegisterComponent {

  public userRegisterCount = 0;
  public isMaxUsers = false;

  public constructor(private _http: HttpClient) { }

  public NewUser(): Promise<any> {
      return new Promise(resolve => {
          resolve(1);
      }).then((res:any) => {

          if (this.userRegisterCount < 5) {
              this.userRegisterCount += res;
          } else {
              this.isMaxUsers = true;
          }

      });
  }
}
