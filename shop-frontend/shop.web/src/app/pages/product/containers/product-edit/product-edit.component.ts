import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";

import { ProductService } from "../../services/product.service";
import { Product } from "../../interfaces/product";

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html'
})
export class ProductEditComponent implements OnInit {

  id!: number;

  constructor(
    private productService: ProductService,
    private route: ActivatedRoute
  ) {
    this.id = 0;
  }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  update(productForm: any): void {
    this.productService.put(productForm.value, this.id).subscribe(() => {});
  }
}
