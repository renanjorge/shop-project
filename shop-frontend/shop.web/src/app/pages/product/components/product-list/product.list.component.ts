import { AfterViewInit, Component, ViewChild } from "@angular/core";
import { MatTableDataSource } from "@angular/material/table";
import { MatPaginator } from "@angular/material/paginator";

import { Product } from "../../interfaces/product";
import { ProductService } from "../../services/product.service";
import { map, startWith, switchMap } from "rxjs";

const DATA = [{
  id: 1,
  name: 'Harry Potter e Ordem da Fênix',
  description: 'Leitura',
  category: 'Livro',
  active: true,
  perishable: true
},
  {
    id: 1,
    name: 'Harry Potter e o Cálice de Fogo',
    description: 'Leitura',
    category: 'Livro',
    active: false,
    perishable: false
  }
];

@Component({
  selector: 'app-list',
  templateUrl: './product.list.component.html'
})
export class ProductListComponent implements AfterViewInit {

  isLoading: boolean = false;

  pageIndex: number = 0;
  pageSize: number = 10;
  totalRows: number = 0;
  pageSizeOptions: number[] = [10, 50, 100];

  displayedColumns: string[] = ['name', 'description', 'category', 'active', 'perishable', 'actions'];
  empData: Product[] = [];
  products = new MatTableDataSource<Product>(DATA);

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  constructor(private productService: ProductService) { }

  ngAfterViewInit() {
    this.products.paginator = this.paginator;

    this.paginator.page
      .pipe(
        startWith({}),
        switchMap(() => {
          return this.listProducts(this.paginator.pageIndex + 1, this.paginator.pageSize)
        }),
        map((data) => {

          if (data == null) return [];

          this.totalRows = data.pagedList.totalRows;
          return data.products;

        })
      ).subscribe((data) => {
        this.empData = data;
        this.products = new MatTableDataSource(this.empData);
      });

  }

  listProducts(pageIndex: number, pageSize: number) {
    return this.productService.getProductsPagedList(pageIndex, pageSize);
  }

}
