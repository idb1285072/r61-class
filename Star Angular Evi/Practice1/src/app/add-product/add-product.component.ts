import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from '../services/product.service';
import { ProductCategory } from '../models/product-category';
import { Product } from '../models/product';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule,ReactiveFormsModule,CommonModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css'
})
export class AddProductComponent  implements OnInit{
  constructor(private service:ProductService,private router:Router,fb:FormBuilder){}
  ngOnInit(): void { }
  productList:Product[]=[];
  prductCategoryList:ProductCategory[]=[];
  productObj:Product={productID:0,name:'',productNumber:'',color:'',standardCost:0,listPrice:0,weight:0,size:0,productCategoryID:0}
  productCateObj:ProductCategory={name:'',productCategoryID:0,products:[]}
  
  deleteProduct(p:Product,arry:any[]){
    const row=arry.findIndex((obj)=>obj.name==p.name && obj.color==p.color && obj.productNumber==p.productNumber)
    if(row>-1){
      arry.splice(row,1)
    }
  }
  addNewProduct(){
    if(this.productObj.name!='' && this.productObj.name!=null){
      var expr=JSON.stringify(this.productObj);
      var obj=JSON.parse(expr);
      this.productList.unshift(obj);
      this.productObj={productID:0,name:'',productNumber:'',color:'',standardCost:0,listPrice:0,weight:0,size:0,productCategoryID:0}
    }
  }
  addCategory(){
    const cate:ProductCategory=
    {
      products:this.productList,
      name:this.productCateObj.name,
      productCategoryID:this.productCateObj.productCategoryID
    }
   this.service.postProduct(cate).subscribe({
    next:x=>{
      console.log(x)
      this.router.navigate(['products'])
    },
    error:err=>{
      console.log(err);
    }
   })
  }
  
}
