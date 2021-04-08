import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from '../app/app.component';
import { HttpClientModule } from '@angular/common/http';

import { TestcaseComponent } from './testcase/testcase.component';



@NgModule({
  declarations: [
    AppComponent,
   
    TestcaseComponent,
    
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
