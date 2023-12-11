import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from "@angular/router";
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';

import { ProductRoutingModule } from "./product.routing.module";
import { ProductListComponent } from "./components/product-list/product.list.component";
import { ProductCreateComponent } from "./components/product-create/product.create.component";
import { ProductEditComponent } from "./components/product-edit/product.edit.component";
import { ProductDeleteComponent } from "./components/product-delete/product.delete.component";

@NgModule({
  declarations: [
    ProductListComponent,
    ProductCreateComponent,
    ProductEditComponent,
    ProductDeleteComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    HttpClientModule,
    RouterModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressBarModule,
    ProductRoutingModule,
    ReactiveFormsModule
  ],
  providers: []
})
export class ProductModule { }
