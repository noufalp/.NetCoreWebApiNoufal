import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { ProductComponent } from './product/product.component';
import { AddProductComponent } from './add-product/add-product.component';
import { ProductEditComponent } from './product-edit/product-edit.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'product', component: ProductComponent },
  { path: 'addproduct', component: AddProductComponent },
  { path: 'editproduct', component: ProductEditComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
