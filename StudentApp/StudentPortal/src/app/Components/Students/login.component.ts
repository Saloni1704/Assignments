import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
 
})
export class LoginComponent implements OnInit{
    signinFormGroup:FormGroup;
    result:any;
constructor(private formbuilder:FormBuilder,private http:HttpClient,private router:Router)
  {}
  ngOnInit(){
    this.signinFormGroup=this.formbuilder.group({
        email:['',Validators.required],
        password:['',Validators.required],
      });
  
}
submit()
  {
    this.http.post<any>('https://localhost:44304/api/login',{Email:this.signinFormGroup.value.email,Password:this.signinFormGroup.value.password}).subscribe(res=>{
        console.log(res);
        
        if(res=="login failed")
        {
            alert("Login Failed");
        }
        else
        {
            sessionStorage.setItem("studentId",res);
            this.router.navigate(['/view',res]);
        }

    })
      

  }
}
