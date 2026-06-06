import { Component, OnInit } from '@angular/core';
import { ProductCategory } from '../models/product-category';
import { ProductService } from '../services/product.service';
import { RouterLink } from '@angular/router';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-view-product',
  standalone: true,
  imports: [RouterLink,CommonModule],
  templateUrl: './view-product.component.html',
  styleUrl: './view-product.component.css'
})
export class ViewProductComponent implements OnInit {
  list:ProductCategory[]=[];
 

  constructor(private service :ProductService){}


  ngOnInit(): void {
    this.getlist();
  }
  getlist(){
    this.service.getAllproducts().subscribe(data=>{
      this.list=data;
    })
  }
  onDelete(cate:ProductCategory){
    const isConfirm=confirm("Are you sure to delete the record of "+cate.name)
    if(isConfirm){
      this.service.deletecategoryAndProductsById(cate.productCategoryID)
      .subscribe((res)=>{
        alert("Deleted successfully");
        this.getlist();
      })
    }
  }

}
