import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { Product } from "../../interfaces/product";
import { ProductService } from "../../services/product.service";

@Component({
  selector: 'app-product-delete',
  templateUrl: './product.delete.component.html'
})
export class ProductDeleteComponent implements OnInit {

  product: Product = {
    id: 0,
    name: "",
    description: "",
    productCategory: {
      name: "",
      description: "",
      isActive: true
    },
    isActive: true,
    isPerishable: true,
  };

  constructor(
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute) { }

  ngOnInit(): void {
    const id = parseInt(this.route.snapshot.paramMap.get('id')!);

    this.productService
      .get(id)
      .subscribe(
        (response) => this.product = response
      );
  }

  delete() : void{
    if (this.product.id) {
      this.productService
        .delete(this.product.id)
        .subscribe(
          data => this.router.navigate(['/product']),
          error => alert("Ops! Algo deu errado.")
        );
    }
  }

}
