import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProductCategory } from '../models/product-category';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
  constructor(private http:HttpClient) { }
  baseUrl='https://localhost:7115/ProductCategories';
  getAllproducts():Observable<ProductCategory[]>{
    return this.http.get<ProductCategory[]>(this.baseUrl);
  }
  deletecategoryAndProductsById(id:number){
    return this.http.delete(`${this.baseUrl}/${id}`)
  }
  postProduct(category:ProductCategory):Observable<ProductCategory>{
    return this.http.post<ProductCategory>(this.baseUrl,category)
  }
  getCategoryAndProductByCateId(id:number){
    return this.http.get<ProductCategory>(this.baseUrl+`/${id}`)
  }
  updateCategoryWithProduct(id:number,category:ProductCategory):Observable<ProductCategory>{
    return this.http.put<ProductCategory>(this.baseUrl+`/${id}`,category)
  }
}
