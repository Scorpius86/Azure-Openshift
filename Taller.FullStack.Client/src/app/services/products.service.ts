import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, Observable, throwError } from 'rxjs';
import { environment } from '../../environments/environment';
import { Product } from '../models/product';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private productsUrl = `${environment.apiServer}/api/Products`;

  constructor(
    private http: HttpClient
  ) { }

  public list(): Observable<Product[]> {
    const listUrl = `${this.productsUrl}`;
    return this.http.get<Product[]>(listUrl)
      .pipe(
        catchError(this.handleError)
      );
  }
  public getByProductId(productId: number): Observable<Product> {
    const getUrl = `${this.productsUrl}/${productId}`;
    return this.http.get<Product>(getUrl)
      .pipe(
        catchError(this.handleError)
      );
  }
  public edit(productId: number, product: Product): Observable<Product> {
    const updateUrl = `${this.productsUrl}/${productId}`;
    return this.http.put<Product>(updateUrl, product)
      .pipe(
        catchError(this.handleError)
      );
  }
  public insert(product: Product): Observable<Product> {
    const insertUrl = `${this.productsUrl}`;
    return this.http.post<Product>(insertUrl, product)
      .pipe(
        catchError(this.handleError)
      );
  }
  public delete(productId: number): Observable<Product> {
    const deleteUrl = `${this.productsUrl}/${productId}`;
    return this.http.delete<Product>(deleteUrl)
      .pipe(
        catchError(this.handleError)
      );
  }

  private handleError(error: HttpErrorResponse) {
    console.error('server error:', error);
    if (error.error instanceof Error) {
      const errMessage = error.error.message;
      return throwError(() => errMessage);
    }
    return throwError(() => error || 'Server error');
  }

}
