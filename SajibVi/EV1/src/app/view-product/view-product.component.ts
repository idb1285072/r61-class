import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { RouterLink } from '@angular/router';
import { ProductService } from '../service/product.service';
import { ProductCategory } from '../models/product-category';

@Component({
  selector: 'app-view-product',
  standalone: true,
  imports: [CommonModule, RouterLink],
  templateUrl: './view-product.component.html',
  styleUrl: './view-product.component.css',
})
export class ViewProductComponent implements OnInit {
  constructor(private service: ProductService) {}
  list: ProductCategory[] = [];

  ngOnInit(): void {
    this.GetList();
  }

  GetList() {
    this.service.getProduct().subscribe((data) => {
      this.list = data;
    });
  }

  onDelete(cate: ProductCategory) {
    var isConf = confirm(`Delete this product ${cate.name}`);
    if (isConf) {
      this.service.deleteProduct(cate.productCategoryID).subscribe(() => {
        alert(`delete successfull`);
        this.GetList();
      });
    }
  }
}
