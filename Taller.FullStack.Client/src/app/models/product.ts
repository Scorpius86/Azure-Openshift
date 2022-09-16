import { Brand } from "./brand";
import { Category } from "./category";

export class Product {
  constructor() {
    this.productId = 0;
    this.productName = '';
    this.brand = new Brand();
    this.category = new Category();
  }
  public productId: number;
  public productName: string;
  public brand: Brand;
  public category: Category;
}
