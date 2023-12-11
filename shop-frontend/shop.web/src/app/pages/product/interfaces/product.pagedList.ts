import { PagedList } from "../../../shared/interfaces/pagedList";
import { Product } from "./product";

export interface ProductPagedList extends PagedList {
  data: Product[]
}
