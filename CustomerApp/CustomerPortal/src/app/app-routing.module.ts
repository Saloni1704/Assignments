import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginCustomerComponent } from './Customer/logincustomer.component';
import { ProductListComponent } from './Product/productlist.component';
import { UpdateCustomerComponent } from './Customer/updatecustomer.component';


const routes: Routes = [
  {
    path:'logincustomer', component:LoginCustomerComponent
  },
  {
    path:'productlist',component:ProductListComponent
  },
  {
    path:'updateCustomer',component:UpdateCustomerComponent
  },
  {
    path:'addproduct',component:ProductListComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }


