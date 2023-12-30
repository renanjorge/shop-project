import { Component, OnInit } from "@angular/core";
import { ActivatedRoute, Router } from "@angular/router";

import { ProductService } from "../../services/product.service";
import { MessageService } from "../../../../shared/services/message.service";

@Component({
  selector: 'app-product-edit',
  templateUrl: './product-edit.component.html'
})
export class ProductEditComponent implements OnInit {

  id!: number;

  constructor(
    private productService: ProductService,
    private messageService: MessageService,
    private route: ActivatedRoute,
    private router: Router
  ) {
    this.id = 0;
  }

  ngOnInit(): void {
    this.id = Number(this.route.snapshot.paramMap.get('id'));
  }

  update(productForm: any): void {
    this.productService.put(productForm.value, this.id).subscribe(
      () => {
        this.messageService.openEditSuccess();
        this.router.navigate(['product']);
      }
    );
  }
}
