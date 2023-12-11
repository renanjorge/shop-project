import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

import { ProductCategoryPagedList } from "../interfaces/productCategory.pagedList";

@Injectable({ providedIn: 'root' })
export class ProductCategoryService {

  private api: string = "http://localhost:5000/api/product-categories";

  constructor(private http: HttpClient) { }

  getAll(): Observable<ProductCategoryPagedList> {
    return this.http.get<ProductCategoryPagedList>(`${this.api}`);
  }
}
