import { Component, OnInit, ViewChild } from '@angular/core';
import { ProductCategory } from '../../../models/product-category';
import { MatTableDataSource } from '@angular/material/table';
import { CategoryService } from '../../../services/category.service';
import { NotifyService } from '../../../services/notify.service';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { ProductDialogComponent } from '../product-dialog/product-dialog.component';

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrl: './category-list.component.css'
})
export class CategoryListComponent implements OnInit{
  
  categories:ProductCategory[]=[];
  dataSource:MatTableDataSource<ProductCategory> = new MatTableDataSource(this.categories);
  columns =['productCategoryID', 'name', 'view', 'actions']
  @ViewChild(MatSort,{static:false}) sort!:MatSort;
  @ViewChild(MatPaginator,{static:false}) paginator!:MatPaginator;
  constructor(
    private catgorySrv:CategoryService,
    private notifySrv:NotifyService,
    private matDialog:MatDialog
  ){}
  showProduct(cat:ProductCategory){
    this.matDialog.open(ProductDialogComponent, {
      data:{id:cat.productCategoryID, categoryName:cat.name},
      width: '650px'
    });
  }
  delete(data:ProductCategory){
    if(confirm('Are you sure to delete?')){
      this.catgorySrv.delete(<number>data.productCategoryID)
      .subscribe({
        next:r=>{
          this.dataSource.data = this.dataSource.data.filter(x=> x.productCategoryID!= data.productCategoryID)
          this.notifySrv.message('Data deleted', 'DISMISS')
        },
        error: err=>{
          this.notifySrv.message('Failed to delete.', 'DISMISS');
        }
      })
    }
  }
  ngOnInit(): void {
   this.catgorySrv.get()
   .subscribe({
    next: r=>{
      this.categories=r;
      console.log(this.categories)
      this.dataSource.data = this.categories;
      this.dataSource.sort = this.sort;
      this.dataSource.paginator = this.paginator;
    },
    error: err=>{
      this.notifySrv.message('Failed to load data', 'DISMISS');
    }
   })
  }
}
