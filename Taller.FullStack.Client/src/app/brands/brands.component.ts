import { Component, OnInit } from '@angular/core';
import { Brand } from '../models/brand';
import { BrandsService } from '../services/brands.service';

@Component({
  selector: 'app-brands',
  templateUrl: './brands.component.html',
  styleUrls: ['./brands.component.css']
})
export class BrandsComponent implements OnInit {

  displayedColumns: string[] = ['brandId', 'brandName', 'actions'];
  brands: Brand[] = [];
  isLoadingResults = true;

  constructor(
    private brandsService: BrandsService
  ) {
  }

  ngOnInit(): void {
    this.listBrands();
  }

  private listBrands() {
    //To Do
    this.isLoadingResults = true;
    this.brandsService.list().subscribe(brands => {
      this.brands = brands;
      this.isLoadingResults = false;
    });
  }

}
