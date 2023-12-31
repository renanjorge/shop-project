import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { ProductPagedList } from "../interfaces/product.pagedList";
import { Product } from "../interfaces/product";
import { AddProduct } from "../interfaces/add.product";
import { EditProduct } from "../interfaces/edit.product";

@Injectable({ providedIn: 'root' })
export class ProductService {

  private API: string = "http://localhost:5000/api/products";

  constructor(private http: HttpClient) { }

  getAll(pageIndex: number, pageSize: number): Observable<ProductPagedList> {
    let params = {
      pageNumber: pageIndex,
      pageSize
    };

    return this.http.get<ProductPagedList>(`${this.API}`, { params });
  }

  get(id: number): Observable<Product> {
    return this.http.get<Product>(`${this.API}/${id}`);
  }

  post(addProduct: AddProduct): Observable<any> {
    return this.http.post<AddProduct>(`${this.API}`, addProduct);
  }

  put(editProduct: EditProduct, id: number): Observable<any> {
    return this.http.put(`${this.API}/${id}`, editProduct);
  }

  delete(id: number): Observable<any> {
     return this.http.delete(`${this.API}/${id}`);
  }
}
