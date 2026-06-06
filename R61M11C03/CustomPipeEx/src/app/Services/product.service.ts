import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../Models/product.model';
import { environment } from '../../environments/environment.development';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  
  apiUrl=environment.apiUrl
    constructor(private client:HttpClient) { }
    Get(){
     return this.client.get<Product[]>(this.apiUrl+"Products");
    }
    GetbyId(id:number){
      return this.client.get<Product>(this.apiUrl+"Products/"+id);
     }
    Save(Product:any){
      //debugger;
    return  this.client.post(this.apiUrl+"Products",Product);
    }
    Update(Product:any){
      //debugger;
     return this.client.put(this.apiUrl+"Products/",Product);
    }
    Delete(id:number){
      return this.client.delete(this.apiUrl+"Products/"+id);
    }
}
