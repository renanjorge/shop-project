import { Component, EventEmitter, Input, OnInit, Output } from "@angular/core";
import { UntypedFormBuilder, UntypedFormGroup, Validators } from "@angular/forms";

import { ProductCategoryService } from "../../../product-category/services/productCategory.service";
import { ProductService } from "../../services/product.service";
import { ProductCategory } from "../../../product-category/interfaces/productCategory";
import { Product } from "../../interfaces/product";
import { ProductCategoryPagedList } from "../../../product-category/interfaces/productCategory.pagedList";

@Component({
  selector: 'app-product-input',
  templateUrl: './product-input.component.html'
})
export class ProductInputComponent implements OnInit {

  @Input() titleForm!: string;
  @Input() subTitleForm!: string;
  @Input() nameSubmitForm!: string;
  @Input() id!: number;

  @Output() submitted = new EventEmitter<any>();

  productForm!: UntypedFormGroup;
  categories: ProductCategory[] = [];

  constructor(
    private formBuilder: UntypedFormBuilder,
    private productService: ProductService,
    private productCategoryService: ProductCategoryService
  ) {
    this.titleForm = 'Formulário';
    this.subTitleForm = '';
    this.nameSubmitForm = 'Salvar';
    this.id = 0;
  }

  ngOnInit(): void {
    this.buildForm();

    if (this.id > 0) {
      this.productService.get(this.id).subscribe((response: Product) => {
        this.productForm.patchValue({
          ...response,
          productCategoryId: response.productCategory.id
        });
      });
    }
  }

  buildForm(): void {
    this.buildComboCategories();

    this.productForm = this.formBuilder.group({
      name: [
        null,
        Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(250)])
      ],
      description: [
        null,
        Validators.compose([Validators.required, Validators.minLength(5), Validators.maxLength(250)])
      ],
      productCategoryId: [
        0,
        [Validators.min(1)]
      ],
      isPerishable: [true],
    });
  }

  buildComboCategories(): void {
    this.productCategoryService.getAll().subscribe((response: ProductCategoryPagedList) => {
      this.categories = response.data
    });
  }

  onSubmit(): void {
    if (this.productForm.valid) {
      this.submitted.emit(this.productForm);
    }
  }
}
