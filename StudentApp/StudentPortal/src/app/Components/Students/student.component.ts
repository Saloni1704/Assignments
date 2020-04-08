import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder, Validators} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import {Router} from '@angular/router';
@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
 
})
export class StudentComponent implements OnInit{
  studentFormGroup:FormGroup;
constructor(private formbuilder:FormBuilder,private http:HttpClient,private router:Router)
  {}
  ngOnInit(){
    this.studentFormGroup=this.formbuilder.group({
      name:['',Validators.required],
      email:['',Validators.required],
      mobileNumber:['',Validators.required],
      password:['',Validators.required],
      courseId:['',Validators.required],
    
      });
  
}
Submit()
  {
    
    this.http.post<any>('https://localhost:44304/api/Student',{StudentName:this.studentFormGroup.value.name,MobileNo:this.studentFormGroup.value.mobileNumber,Email:this.studentFormGroup.value.email,Password:this.studentFormGroup.value.password,CourseId:this.studentFormGroup.value.courseid}).subscribe(res=>{
        console.log(res);
        if(res =="Added Succesfully")
        {
          this.router.navigate(['/update']);
        }
        else{
          alert("Please Fill Out all details");
        }
      });
  }
}
