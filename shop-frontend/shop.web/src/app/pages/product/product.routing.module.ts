import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

import { ProductListComponent } from "./components/product-list/product.list.component";
import { ProductCreateComponent } from "./components/product-create/product.create.component";
import { ProductEditComponent } from "./components/product-edit/product.edit.component";
import { ProductDeleteComponent } from "./components/product-delete/product.delete.component";

const routes: Routes = [
  {
    path: 'product',
    component: ProductListComponent
  },
  {
    path: 'product/create',
    component: ProductCreateComponent
  },
  {
    path: 'product/edit/:id',
    component: ProductEditComponent
  },
  {
    path: 'product/delete/:id',
    component: ProductDeleteComponent
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
