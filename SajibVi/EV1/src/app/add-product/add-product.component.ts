import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ProductService } from '../service/product.service';
import { Router } from '@angular/router';
import { Product } from '../models/product';
import { ProductCategory } from '../models/product-category';

@Component({
  selector: 'app-add-product',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './add-product.component.html',
  styleUrl: './add-product.component.css',
})
export class AddProductComponent implements OnInit {
  constructor(
    private service: ProductService,
    private router: Router,
    fb: FormBuilder
  ) {}

  productList: Product[] = [];
  categoryList: ProductCategory[] = [];
  productOBJ: Product = {
    productID: 0,
    name: '',
    productNumber: '',
    color: '',
    standardCost: 0,
    listPrice: 0,
    size: 0,
    weight: 0,
    productCategoryID: 0,
  };
  categoryOBJ: ProductCategory = {
    productCategoryID: 0,
    name: '',
    products: [],
  };

  ngOnInit(): void {
    throw new Error('Method not implemented.');
  }

  addProduct() {
    if (this.productOBJ.name != '' && this.productOBJ.name != null) {
      const expr = JSON.stringify(this.productOBJ);
      const obj = JSON.parse(expr);
      this.productList.unshift(obj);
      this.productOBJ = {
        productID: 0,
        name: '',
        productNumber: '',
        color: '',
        standardCost: 0,
        listPrice: 0,
        size: 0,
        weight: 0,
        productCategoryID: 0,
      };
    }
  }

  saveCategory() {
    const cate: ProductCategory = {
      productCategoryID: this.categoryOBJ.productCategoryID,
      name: this.categoryOBJ.name,
      products: this.productList,
    };
    this.service.postProduct(cate).subscribe({
      next: (x) => {
        alert(`seve successful`);
        this.router.navigate(['Index']);
      },
      error: (err) => {
        alert(`Erro occour ${err}`);
      },
    });
  }

  removeProduct(p: Product, arry: any[]) {
    var r = arry.findIndex(
      (o) =>
        o.name == p.name &&
        o.productNumber == p.productNumber &&
        o.color == p.color
    );
    if (r > -1) {
      arry.splice(r, 1);
    }
  }
}
