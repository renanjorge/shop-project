import { PagedList } from "../../../shared/interfaces/pagedList";
import { Product } from "./product";

export interface ProductPagedList {
  products: Product[],
  pagedList: PagedList
}
