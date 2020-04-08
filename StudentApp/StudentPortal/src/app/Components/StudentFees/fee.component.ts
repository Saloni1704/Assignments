import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-fees',
  templateUrl: './fee.component.html',
 
})
export class FeeComponent implements OnInit{
  feeFormGroup:FormGroup;
  id:any
constructor(private formbuilder:FormBuilder,private http:HttpClient,private router:Router,private activated:ActivatedRoute)
  {}
  ngOnInit(){
    this.feeFormGroup=this.formbuilder.group({
      feeAmount:[''],
    
      });
  
}
Submit()
  {
    this.id=this.activated.snapshot.paramMap.get("id");
    this.http.post<any>('https://localhost:44304/api/Fee',{FeeAmount:this.feeFormGroup.value.feeAmount,StudentId:this.id}).subscribe(res=>{
        console.log(res);
        if(res =="Fee Added Succesfully")
        {
          alert("Fee Added successfully")
        }
        else{
          alert("Please Fill Out all details");
        }
      });
      console.log(this.feeFormGroup.value);

  }
}
