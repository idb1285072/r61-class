import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Product } from '../Models/product.model';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  Product:Product={
    id: 0,
    name: ''
  }
     
     apiUrl=environment.apiUrl
       constructor(private client:HttpClient) { }
       Get(){
        return this.client.get<Product[]>(this.apiUrl+"Products");
       }
       GetbyId(id:number){
         return this.client.get<Product>(this.apiUrl+"Products/"+id);
        }
       Save( ){
         //debugger;
         console.log(this.Product)
       return  this.client.post(this.apiUrl+"Products",this.Product);
       }
       Update(Product:any){
         //debugger;
        return this.client.put(this.apiUrl+"Products/",Product);
       }
       Delete(id:number){
         return this.client.delete(this.apiUrl+"Products/"+id);
       }
}
