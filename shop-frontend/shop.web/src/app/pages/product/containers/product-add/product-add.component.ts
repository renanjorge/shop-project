import { Component, OnInit } from "@angular/core";
import { Router } from "@angular/router";

import { ProductService } from "../../services/product.service";
import { MessageService } from "../../../../shared/services/message.service";

@Component({
  selector: 'app-product-add',
  templateUrl: './product-add.component.html'
})
export class ProductAddComponent implements OnInit {

  constructor(
    private productService: ProductService,
    private messageService: MessageService,
    private router: Router
  ) { }

  ngOnInit(): void { }

  add(productForm: any): void {
    this.productService.post(productForm.value).subscribe(
      () => {
        this.messageService.openAddSuccess();
        this.router.navigate(['product']);
      }
    );
  }
}
