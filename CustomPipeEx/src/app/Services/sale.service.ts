import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { HttpClient } from '@angular/common/http';
import { Sale } from '../Models/sale.model';

@Injectable({
  providedIn: 'root'
})
export class SaleService {

 sale:Sale={
   id: 0,
   salenumber: '',
   customerId: 0,
   orderDate: new Date,
   isDelivered: false,
   customerName: '',
   salesDetails: []
 }
    
    apiUrl=environment.apiUrl
      constructor(private client:HttpClient) { }
      Get(){
       return this.client.get<Sale[]>(this.apiUrl+"Sales");
      }
      GetbyId(id:number){
        return this.client.get<Sale>(this.apiUrl+"Sales/"+id);
       }
      Save( ){
        //debugger;
      return  this.client.post(this.apiUrl+"Sales",this.sale);
      }
      Update(Sale:any){
        //debugger;
       return this.client.put(this.apiUrl+"Sales/",Sale);
      }
      Delete(id:number){
        return this.client.delete(this.apiUrl+"Sales/"+id);
      }
}
