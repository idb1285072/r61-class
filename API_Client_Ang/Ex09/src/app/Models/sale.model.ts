import { SaleDetails } from "./sale-details.model";

export class Sale {
  id: number = 0;

  customerName: string = '';

  orderDate!: Date;

  picture: string = '';

  isDelivered: boolean = false;
  details:SaleDetails[]=[]
}
 

