import { Injectable } from '@angular/core';
import { Sale } from '../Models/sale.model';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SaleService {

 
  sale:Sale={
    id: 0,
    customerName: '',
    orderDate: new Date,
    picture: '',
    isDelivered: false,
    details: []
  }
     
     apiUrl=environment.apiUrl
       constructor(private client:HttpClient) { }
       Get(){
        return this.client.get<Sale[]>(this.apiUrl+"Sales");
       }
       GetbyId(id:number){
         return this.client.get<Sale>(this.apiUrl+"Sales/"+id);
        }
       Save(formData:any ){
         //debugger;
         console.log(this.sale)
       return  this.client.post(this.apiUrl+"Sales",formData);
       }
       Update(Sale:any){
         //debugger;
        return this.client.put(this.apiUrl+"Sales/",Sale);
       }
       Delete(id:number){
         return this.client.delete(this.apiUrl+"Sales/"+id);
       }
}
