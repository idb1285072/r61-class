import { SalesDetails } from "./sales-details.model";

export class Sale {
     id :number=0;
    salenumber:string=""
  customerId:number=0;
 orderDate:Date=new Date
 isDelivered:boolean=false
  customerName :string=""
 salesDetails:  SalesDetails[]=[]
}
