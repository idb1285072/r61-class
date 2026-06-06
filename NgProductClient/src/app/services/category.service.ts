import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductCategory } from '../models/product-category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }
  get():Observable<ProductCategory[]>{
    return this.http.get<ProductCategory[]>(`http://localhost:5289/ProductCategories`);
  }
  getById(id:number):Observable<ProductCategory>{
    return this.http.get<ProductCategory>(`http://localhost:5289/ProductCategories/${id}`);
  }
  create(data:ProductCategory):Observable<ProductCategory>{
    return this.http.post<ProductCategory>(`http://localhost:5289/ProductCategories`, data);
  }
  update(data:ProductCategory):Observable<any>{
    return this.http.put<any>(`http://localhost:5289/ProductCategories/${data.productCategoryID}`, data);
  }
  delete(id:number):Observable<any>{
    return this.http.delete<any>(`http://localhost:5289/ProductCategories/${id}`);
  }
}
