import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { APP_ROUTING } from './app-routing.module';
import { AppComponent } from './app.component';
import {ReactiveFormsModule} from '@angular/forms';
import {StudentComponent} from './Components/Students/student.component';
import {LoginComponent} from './Components/Students/login.component';
import {StudentUpdateComponent} from './Components/Students/studentUpdate.component';
import {ViewStudentComponent} from './Components/Students/viewStudent.component';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import {FeeComponent} from './Components/StudentFees/fee.component';

@NgModule({
  declarations: [
    AppComponent,StudentComponent,LoginComponent,StudentUpdateComponent,ViewStudentComponent,FeeComponent
  ],
  imports: [
    BrowserModule,
    APP_ROUTING,ReactiveFormsModule,HttpClientModule
  ],
  providers: [],
  exports:[RouterModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
