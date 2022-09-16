import { Component, OnInit } from '@angular/core';
import { Category } from '../models/category';
import { CategoriesService } from '../services/categories.service';

@Component({
  selector: 'app-categories',
  templateUrl: './categories.component.html',
  styleUrls: ['./categories.component.css']
})
export class CategoriesComponent implements OnInit {

  displayedColumns: string[] = ['categoryId', 'categoryName', 'actions'];
  categories: Category[] = [];
  isLoadingResults = true;

  constructor(
    private categoriesService: CategoriesService
  ) {
  }

  ngOnInit(): void {
    this.listCategories();
  }

  private listCategories() {
    this.isLoadingResults = true;
    this.categoriesService.list().subscribe(categories => {
      this.categories = categories;
      this.isLoadingResults = false;
    });
  }

}
