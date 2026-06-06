import { Component, OnInit } from '@angular/core';
import { SaleDetails } from '../../Models/sale-details.model';
import { ProductService } from '../../Services/product.service';
import { Product } from '../../Models/product.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { SaleService } from '../../Services/sale.service';

@Component({
  selector: 'app-adddetails',
  imports: [FormsModule,CommonModule],
  templateUrl: './adddetails.component.html',
  styleUrl: './adddetails.component.css',
})
export class AdddetailsComponent implements OnInit {
  saleDetails: SaleDetails = {
    Id: 0,
    SalesID: 0,
    ProductId: 0,
    Price: 0,
    qty: 0,
    total: 0,
    ProductName: '',
  };
  updatePrice(p:any) {
console.log(p)
console.log(p.selectedIndex-1)
console.log(this.prdList[p.selectedIndex-1].price)
this.saleDetails.Price=this.prdList[p.selectedIndex-1].price
  }
  updateTotal(){
    this.saleDetails.total= this.saleDetails.qty*this.saleDetails.Price
  }
  prdList: Product[] = [];
  constructor(private psev: ProductService, private sSrv:SaleService) {}
  ngOnInit(): void {
   this.loadProduct()
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
    this.sSrv.sale.salesDetails.push(f.value)
  }
}
