import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ProductComponent } from "./components/product/product.component";
import { ProductAddComponent } from "./containers/product-add/product-add.component";
import { ProductEditComponent } from "./containers/product-edit/product-edit.component";

const routes: Routes = [
  {
    path: 'product',
    component: ProductComponent
  },
  {
    path: 'product/add',
    component: ProductAddComponent
  },
  {
    path: 'product/edit/:id',
    component: ProductEditComponent
  }
];

@NgModule({
  imports: [
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class ProductRoutingModule { }
