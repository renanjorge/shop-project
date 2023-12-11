import { PagedList } from "../../../shared/interfaces/pagedList";
import { ProductCategory } from "./productCategory";

export interface ProductCategoryPagedList extends PagedList {
  data: ProductCategory[]
}
