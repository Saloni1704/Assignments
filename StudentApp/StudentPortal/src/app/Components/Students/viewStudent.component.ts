import { Component,OnInit } from '@angular/core';
import {FormGroup,FormBuilder} from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
@Component({
  selector: 'app-viewStudent',
  templateUrl: './viewStudent.component.html',
 
})
export class ViewStudentComponent implements OnInit{
 result:any;
 id:any;
constructor(private http:HttpClient,private activated:ActivatedRoute)
  {}                                                                
  ngOnInit(){
    this.id=this.activated.snapshot.paramMap.get("id");
    this.http.get<any>('https://localhost:44304/api/Student/'+this.id).subscribe(res=>{
        this.result=res;
        console.log(this.result);
        
    });
   
}
delete()
{
    this.id=this.activated.snapshot.paramMap.get("id");
    this.http.delete<any>('https://localhost:44304/api/Student/'+this.id).subscribe(res=>{
        this.result=res;
        console.log(this.result);
    });
}
}
  



