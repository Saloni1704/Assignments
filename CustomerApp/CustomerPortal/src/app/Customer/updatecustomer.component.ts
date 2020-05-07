import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators,ReactiveFormsModule} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';
import { Session } from 'protractor';


@Component({
  selector: 'update',
  templateUrl: './updatecustomer.component.html'
  
})
export class UpdateCustomerComponent implements OnInit  {
customerUpdateFormGroup:FormGroup;
id:any;
result:any;
constructor(private formbuilder:FormBuilder,private router:Router,private http:HttpClient)
  {}
  ngOnInit(){

    this.id=sessionStorage.getItem(CustomerId);
    
   this.http.get<any>('https://localhost:44303/Customer/'+this.id).subscribe(res=>
   {
     this.result=res;
     console.log(this.result);
   }
   ) ;
    
    this.  customerUpdateFormGroup=this.formbuilder.group({
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
 Update(id)
 {
    this.http.put<any>('https://localhost:44303/api/Customer',{FirstName:this.customerUpdateFormGroup.value.fname,LastName:this.customerUpdateFormGroup.value.lname,MobileNumber:this.customerUpdateFormGroup.value.mobileNumber,Email:this.customerUpdateFormGroup.value.email,Password:this.customerUpdateFormGroup.value.password,Address:this.customerUpdateFormGroup.value.address,Gender:this.customerUpdateFormGroup.value.gender,DOB:this.customerUpdateFormGroup.value.dob,CustomerNumber:this.customerUpdateFormGroup.value.cusno,CustomerId:this.id}).subscribe(res=>{
        console.log(res);
        
      });
      this.router.navigate(['/productlist']);
 }
 Delete(id)
  {
 this.http.delete<any>('https://localhost:44303/Product/'+id).subscribe(res=>
 {
   console.log(res);
 }
 );
  
  }
}

