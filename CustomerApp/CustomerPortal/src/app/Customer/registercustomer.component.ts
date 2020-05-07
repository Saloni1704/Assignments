import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';

@Component({
  selector: 'register',
  templateUrl: './registercustomer.component.html'
  
})
export class RegisterCustomerComponent implements OnInit  {
customerFormGroup:FormGroup;
constructor(private formbuilder:FormBuilder,private router:Router,private http:HttpClient)
  {}
  ngOnInit(){
    this.  customerFormGroup=this.formbuilder.group({
      fname:['',Validators.required],
      lname:['',Validators.required],
      email:['',Validators.required],
      password:['',Validators.required],
      mobileNumber:['',Validators.required],
      address:['',Validators.required],
      gender:['',Validators.required],
      dob:['',Validators.required]
});

  }
  Register()
  {
    this.http.post<any>('https://localhost:44303/api/Customer',{FirstName:this.customerFormGroup.value.fname,LastName:this.customerFormGroup.value.lname,MobileNumber:this.customerFormGroup.value.mobileNumber,Email:this.customerFormGroup.value.email,Password:this.customerFormGroup.value.password,Address:this.customerFormGroup.value.address,Gender:this.customerFormGroup.value.gender,DOB:this.customerFormGroup.value.dob}).subscribe(res=>{
        console.log(res);
        
      });
      this.router.navigate(['/logincustomer']);
    }
  
  }


