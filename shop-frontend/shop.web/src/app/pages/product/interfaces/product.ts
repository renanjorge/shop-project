import { ProductCategory } from "../../product-category/interfaces/productCategory";

export interface Product {
  id?: number;
  name: string;
  description: string;
  productCategory: ProductCategory;
  isActive: boolean;
  isPerishable: boolean;
}
