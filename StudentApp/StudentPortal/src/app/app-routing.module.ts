import { NgModule, ModuleWithProviders } from '@angular/core';
import { Routes, RouterModule, NoPreloading } from '@angular/router';
import {StudentComponent} from './Components/Students/student.component';
import {LoginComponent} from './Components/Students/login.component';
import {StudentUpdateComponent} from './Components/Students/studentUpdate.component';
import {ViewStudentComponent} from './Components/Students/viewStudent.component';
import {FeeComponent} from './Components/StudentFees/fee.component';
// @NgModule({
//   imports: [RouterModule.forRoot(routes)],
//   exports: [RouterModule]
// })

const routes: Routes = [
  {
    path: 'fee/:id', component: FeeComponent
  },
  {
    path:'view/:id', component:ViewStudentComponent
  } ,
  {
    path:'signin', component:LoginComponent
  },
  {
    path:'signup', component:StudentComponent
  },
  {
    path:'update/:id', component:StudentUpdateComponent
  },
  

];



export const APP_ROUTING: ModuleWithProviders = RouterModule.forRoot(routes, {
  preloadingStrategy: NoPreloading,
});