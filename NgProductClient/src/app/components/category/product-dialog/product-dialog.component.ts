import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { Product } from '../../../models/product';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { CategoryService } from '../../../services/category.service';
import { NotifyService } from '../../../services/notify.service';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DialogData } from '../../../models/dialog-data';

@Component({
  selector: 'app-product-dialog',
  templateUrl: './product-dialog.component.html',
  styleUrl: './product-dialog.component.css'
})
export class ProductDialogComponent implements OnInit{
  

  products:Product[]=[];
  dataSource:MatTableDataSource<Product> = new MatTableDataSource(this.products);
  columns =['name', 'productNumber', 'color', 'standardCost', 'size']
  @ViewChild(MatSort,{static:false}) sort!:MatSort;
  @ViewChild(MatPaginator,{static:false}) paginator!:MatPaginator;
  constructor(
    private categorySrv:CategoryService,
    private notifySrv:NotifyService,
    @Inject(MAT_DIALOG_DATA) public data:DialogData
  ){

  }
  ngOnInit(): void {
    console.log(this.data)
    this.categorySrv.getById(<number>this.data.id)
    .subscribe({
      next:r=>{
        console.log(r)
        this.products= r.products as Product[];
        this.dataSource.data= this.products;
        this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    },
    error: err=>{
      this.notifySrv.message('Failed to load data', 'DISMISS');
    }
    })
  }
}
