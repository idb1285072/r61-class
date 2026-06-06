import { Component, Inject } from '@angular/core';
import { SaleDetails } from '../../Models/sale-details.model';
import { Product } from '../../Models/product.model';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { ProductService } from '../../Services/product.service';
import { SaleService } from '../../Services/sale.service';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-adddetails',
  imports: [FormsModule,CommonModule],
  templateUrl: './adddetails.component.html',
  styleUrl: './adddetails.component.css'
})
export class AdddetailsComponent {
  saleDetails: SaleDetails = {
    id: 0,
    orderId: 0,
    productId: 0,
    price: 0,
    productName: ''
  };
  
  updatePrice(p:any) {
console.log(p)
console.log(p.selectedIndex-1)

this.saleDetails.productName=this.prdList[p.selectedIndex-1].name
  }
  
  prdList: Product[] = [];
  constructor(
    @Inject(MAT_DIALOG_DATA) public data:any,
    private psev: ProductService, private sSrv:SaleService
    , public dialogRef:MatDialogRef<AdddetailsComponent>,
  ) {}
  ngOnInit(): void {
   this.loadProduct()
   console.log(this.data.orderIndex)
   if(this.data.orderIndex==null )
    {
      this.saleDetails={
        id: 0,
        orderId: 0,
        productId: 0,
        price: 0,
        productName: ''
    };     
    }
    else
    {
      this.saleDetails=Object.assign({}, this.sSrv.sale.details[this.data.orderIndex]);
    }
  }
  loadProduct() {
    this.psev.Get().subscribe({
      next: (res) => {
        this.prdList = res;
        console.log(res);
      },
      error: (err) => {
        console.log(err);
      },
    });
  }
  onSubmit(f: any) {

    console.log(f.value)
    // this.sSrv.sale.salesDetails.push(f.value)
    if(this.data.orderIndex==null )
      {
       this.sSrv.sale.details.push(f.value);
      }
      else
      {
        this.sSrv.sale.details[this.data.orderIndex]=f.value;
      }
    this.dialogRef.close();
  }
  closeDialog(){
    this.dialogRef.close();
  }
}
