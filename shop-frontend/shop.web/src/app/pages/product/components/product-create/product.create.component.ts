import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";

import { ProductService } from "../../services/product.service";
import { ProductCategoryService } from "../../../product-category/services/productCategory.service";
import { ProductCategoryPagedList } from "../../../product-category/interfaces/productCategory.pagedList";
import { ProductCategory } from "../../../product-category/interfaces/productCategory";

@Component({
  selector: "app-product-create",
  templateUrl: "./product.create.component.html"
})
export class ProductCreateComponent implements OnInit {

  addProductForm: FormGroup = new FormGroup({});
  categories: ProductCategory[] = [];

  constructor(
    private productService: ProductService,
    private productCategoryService: ProductCategoryService,
    private router: Router,
    private formBuilder: FormBuilder) { }

  ngOnInit() : void {
    this.comboCategories();
    this.addProductForm = this.formBuilder.group({
      name: ['', Validators.compose([
        Validators.required,
        Validators.pattern(/(.|\s)*\S(.|\s)*/),
        Validators.minLength(5),
        Validators.maxLength(250)
      ])],
      description: ['', Validators.compose([
        Validators.required,
        Validators.pattern(/(.|\s)*\S(.|\s)*/),
        Validators.minLength(5),
        Validators.maxLength(250)
      ])],
      productCategoryId: [0, [Validators.min(1)]],
      isPerishable: [true]
    });
  }

  comboCategories() : void {
    this.productCategoryService
      .getAll()
      .subscribe((response: ProductCategoryPagedList) => this.categories = response.data);
  }

  save(): void{
    this.productService
      .post(this.addProductForm.value)
      .subscribe(
        data => this.router.navigate(['/product']),
        error => alert("Ops! Algo deu errado.")
      );
  }

  validate(control: string) : string {
    if (this.addProductForm.get(control)?.invalid && this.addProductForm.get(control)?.touched)
      return "border border-1 border-danger";
    else
      return "";
  }
}
