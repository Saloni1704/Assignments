import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-student',
  templateUrl: './studentUpdate.component.html',
 
})
export class StudentUpdateComponent implements OnInit{
 updateFormGroup:FormGroup;
 id:any;
 result:any;
constructor(private formbuilder:FormBuilder,private http:HttpClient,private activated:ActivatedRoute)
  {}
  ngOnInit(){
    this.updateFormGroup=this.formbuilder.group({
        studentId:['',Validators.required],
      name:['',Validators.required],
      email:['',Validators.required],
      mobileNumber:['',Validators.required],
      password:['',Validators.required],
      courseId:['',Validators.required],
    
      });
    this.id=this.activated.snapshot.paramMap.get("id");
    this.http.get<any>('https://localhost:44304/api/Student/'+this.id).subscribe(res=>{
        this.result=res;
        console.log(this.result);
        
    });
  
}
Submit()
  {
    this.http.put<any>('https://localhost:44304/api/Student',{StudentId:this.updateFormGroup.value.studentId,StudentName:this.updateFormGroup.value.name,MobileNo:this.updateFormGroup.value.mobileNumber,Email:this.updateFormGroup.value.email,Password:this.updateFormGroup.value.password,CourseId:this.updateFormGroup.value.courseid}).subscribe(res=>{
        console.log(res);
        
      });
      console.log(this.updateFormGroup.value);

  }
}
