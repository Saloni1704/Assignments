import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators,ReactiveFormsModule} from '@angular/forms';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import {Router} from '@angular/router';
import { Session } from 'protractor';


@Component({
  selector: 'login',
  templateUrl: './logincustomer.component.html'
  
})
export class LoginCustomerComponent implements OnInit  {
customerLoginFormGroup:FormGroup;
h:any;
result:any;
constructor(private formbuilder:FormBuilder,private router:Router,private http:HttpClient)
  {}
  ngOnInit(){
    this.  customerLoginFormGroup=this.formbuilder.group({
      
      email:['',Validators.required],
      password:['',Validators.required]
     
});

  }
  Login()
  {
      let header=new HttpHeaders();
      header=header.append('Email',this.customerLoginFormGroup.value.email);
      header=header.append('Password',this.customerLoginFormGroup.value.password);
     
    this.http.get<any>('https://localhost:44303/api/Customer',{header:header}).subscribe(res=>{
        console.log(res);
        this.result=res;
      });
      this.router.navigate(['/updateCustomer']);
      sessionStorage.setItem("CustomerId",this.result);
      this.router.navigate(['/updateCustomer']);
      if(this.result=="")
      sessionStorage.setItem("CustomerId",this.result);
      else
      alert("Invalid");
    }
  
  }


