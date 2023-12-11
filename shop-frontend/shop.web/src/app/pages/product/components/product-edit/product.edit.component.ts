import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { ProductService } from "../../services/product.service";
import { ProductCategoryService } from "../../../product-category/services/productCategory.service";
import { ProductCategory } from "../../../product-category/interfaces/productCategory";
import { ProductCategoryPagedList } from "../../../product-category/interfaces/productCategory.pagedList";
import { FormBuilder, FormGroup } from "@angular/forms";

@Component({
  selector: "app-product-edit",
  templateUrl: "./product.edit.component.html"
})
export class ProductEditComponent implements OnInit {

  id: number = 0;
  editProductForm!: FormGroup;
  categories: ProductCategory[] = [];

  constructor(
    private productService: ProductService,
    private productCategoryService: ProductCategoryService,
    private router: Router,
    private route: ActivatedRoute,
    private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.comboCategories();
    this.id = parseInt(this.route.snapshot.paramMap.get('id')!);

    this.productService
      .get(this.id)
      .subscribe((response) =>
        this.editProductForm = this.formBuilder.group({
          name: [response.name],
          description: [response.description],
          productCategoryId: [response.productCategory.id],
          isPerishable: [response.isPerishable]
        })
      )
  }

  comboCategories() : void {
    this.productCategoryService
      .getAll()
      .subscribe((response: ProductCategoryPagedList) => this.categories = response.data);
  }

  save(): void {
    this.productService
      .put(this.editProductForm.value, this.id)
      .subscribe(
        data => this.router.navigate(['/product']),
        error => alert("Ops! Algo deu errado.")
      );
  }

}
