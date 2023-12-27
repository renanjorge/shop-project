import { AfterViewInit, Component, ViewChild } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";
import { MatDialog } from "@angular/material/dialog";

import { Product } from "../../interfaces/product";
import { ProductService } from "../../services/product.service";
import { map, startWith, switchMap } from "rxjs";
import { ConfirmationDialogComponent } from "../../../../shared/components/confirmation-dialog/confirmation-dialog.component";

@Component({
  selector: 'app-product-grid',
  templateUrl: './product-grid.component.html'
})
export class ProductGridComponent implements AfterViewInit {

  isLoading!: boolean;

  pageIndex!: number;
  pageSize!: number;
  totalRows!: number;
  pageSizeOptions!: number[];

  displayedColumns!: string[];
  empData: Product[] = [];
  products = new MatTableDataSource<Product>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(
    private productService: ProductService,
    private dialog: MatDialog
  ) {
    this.isLoading = true;
    this.pageIndex = 0;
    this.pageSize = 5;
    this.totalRows = 0;
    this.pageSizeOptions = [5, 10, 50, 100];
    this.displayedColumns = ['name', 'category', 'perishable', 'active', 'actions'];
  }

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

  delete(row: Product) {
    const data = {
      content: `Confirma a exclusão do produto "${row.name}"?`
    };

    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      width: '25%',
      data
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.productService.delete(Number(row.id)).subscribe(() => { });
      }
    });
  }
}
