import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from "@angular/router";
import { MaterialModule } from "../../shared/material.module";

import { ProductRoutingModule } from "./product.routing.module";
import { ProductComponent } from "./components/product/product.component";
import { ProductGridComponent } from "./containers/product-grid/product-grid.component";
import { ProductInputComponent } from "./containers/product-input/product-input.component";
import { ProductAddComponent } from "./containers/product-add/product-add.component";
import { ProductEditComponent } from "./containers/product-edit/product-edit.component";

@NgModule({
  declarations: [
    ProductComponent,
    ProductGridComponent,
    ProductInputComponent,
    ProductAddComponent,
    ProductEditComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    MaterialModule,
    ProductRoutingModule,
    ReactiveFormsModule
  ],
  providers: []
})
export class ProductModule { }
