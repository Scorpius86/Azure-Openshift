import { Component, OnInit } from '@angular/core';
import { Product } from '../models/product';
import { ProductsService } from '../services/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {

  displayedColumns: string[] = ['productId', 'productName', 'brandName','categoryName', 'actions'];
  products: Product[] = [];
  isLoadingResults = true;

  constructor(
    private productsService: ProductsService
  ) {
  }

  ngOnInit(): void {
    this.listProducts();
  }

  private listProducts() {
    this.isLoadingResults = true;
    this.productsService.list().subscribe(products => {
      this.products = products;
      this.isLoadingResults = false;
    });
  }

}
