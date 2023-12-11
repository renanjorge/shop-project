import { AfterViewInit, Component, ViewChild } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";

import { Product } from "../../interfaces/product";
import { ProductService } from "../../services/product.service";
import { map, startWith, switchMap } from "rxjs";

@Component({
  selector: 'app-product-list',
  templateUrl: './product.list.component.html'
})
export class ProductListComponent implements AfterViewInit {

  isLoading: boolean = true;

  pageIndex: number = 0;
  pageSize: number = 5;
  totalRows: number = 0;
  pageSizeOptions: number[] = [5, 10, 50, 100];

  displayedColumns: string[] = ['name', 'category', 'perishable', 'active', 'actions'];
  empData: Product[] = [];
  products = new MatTableDataSource<Product>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private productService: ProductService) { }

  ngAfterViewInit() {
    this.products.paginator = this.paginator;

    this.paginator.page
      .pipe(
        startWith({}),
        switchMap(() => {
          this.isLoading = true;
          return this.list(this.paginator.pageIndex + 1, this.paginator.pageSize);
        }),
        map((response) => {

          if (response == null) return [];

          this.totalRows = response.recordsTotal;
          return response.data;
        })
      ).subscribe((data) => {
        setTimeout(() => {
          this.empData = data;
          this.products = new MatTableDataSource(this.empData);
          this.isLoading = false;
        }, 700);
      });

  }

  list(pageIndex: number, pageSize: number) {
    return this.productService.getAll(pageIndex, pageSize);
  }

  delete() { }

}
