import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {

  public userSignupCount = 0;
  public isMaxUsers = false;

  public constructor(private _http: HttpClient) { }

  public addNewUser(): Promise<any> {
      return new Promise(resolve => {
          resolve(1);
      }).then((res:any) => {

          if (this.userSignupCount < 5) {
              this.userSignupCount += res;
          } else {
              this.isMaxUsers = true;
          }

      });
  }

  public checkStatus(): Promise<any> {
      return this._http.get<any>('https://httpstat.us/200').toPromise();
  }
}
