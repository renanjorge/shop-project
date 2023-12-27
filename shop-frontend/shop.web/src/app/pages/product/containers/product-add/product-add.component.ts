import { Component, OnInit } from "@angular/core";

import { ProductService } from "../../services/product.service";
import { Product } from "../../interfaces/product";

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html'
})
export class ProductAddComponent implements OnInit {

  constructor(
    private productService: ProductService
  ) { }

  ngOnInit(): void { }

  add(productForm: any): void {
    this.productService.post(productForm.value).subscribe((response: Product) => {});
  }
}
