import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { ProductPagedList } from "../interfaces/product.pagedList";
import { Product } from "../interfaces/product";

@Injectable({ providedIn: 'root' })
export class ProductService {

  private api: string = "http://localhost:3000";

  constructor(private http: HttpClient) { }

  getProductsPagedList(pageIndex: number, pageSize: number): Observable<ProductPagedList> {
    let params = {
      pageIndex,
      pageSize
    };

    return this.http.get<ProductPagedList>(`${this.api}/products/pagedList`, { params });
  }

  getProduct(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.api}/products/${id}`);
  }

  postProduct(product: Product) {
    this.http.post(`${this.api}/products`, product);
  }

  putProduct(product: Product) {
    this.http.put(`${this.api}/products`, product);
  }

  deleteProduct(id: number) {
    this.http.delete(`${this.api}/products/${id}`);
  }
}
