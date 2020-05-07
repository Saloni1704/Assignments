import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RegisterCustomerComponent } from './Customer/registercustomer.component';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import {Router, RouterModule} from '@angular/router';
import { LoginCustomerComponent } from './Customer/logincustomer.component';
import { ProductListComponent } from './Product/productlist.component';
import { UpdateCustomerComponent } from './Customer/updatecustomer.component';

@NgModule({
  declarations: [
     AppComponent,RegisterCustomerComponent,LoginCustomerComponent,ProductListComponent,UpdateCustomerComponent,ProductListComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,ReactiveFormsModule,RouterModule,HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
