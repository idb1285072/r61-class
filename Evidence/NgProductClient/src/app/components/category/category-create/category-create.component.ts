import { Component, OnInit } from '@angular/core';
import { ProductCategory } from '../../../models/product-category';
import { FormArray, FormControl, FormGroup, Validators } from '@angular/forms';
import { CategoryService } from '../../../services/category.service';
import { NotifyService } from '../../../services/notify.service';

@Component({
  selector: 'app-category-create',
  templateUrl: './category-create.component.html',
  styleUrl: './category-create.component.css'
})
export class CategoryCreateComponent implements OnInit {
    
    category:ProductCategory ={};
    categoryForm:FormGroup = new FormGroup({
      name: new FormControl('',Validators.required),
      products: new FormArray([])
    });
    constructor(
      private categorySrv:CategoryService,
      private notifySrv:NotifyService
    ){}
    get f(){
      return this.categoryForm.controls;
    }
    get products (){
      return this.categoryForm.controls['products'] as FormArray;
    }
    addProduct(){
      this.products.push(new FormGroup({
        name:new FormControl('',Validators.required),
        productNumber:new FormControl('',Validators.required),
        color:new FormControl('',Validators.required),
        standardCost:new FormControl(undefined,Validators.required),
        listPrice:new FormControl(undefined,Validators.required),
        size: new FormControl(undefined,Validators.required),
        weight: new FormControl(undefined,Validators.required)
      }));
    }
    remove(index:number){
      this.products.removeAt(index);
    }
    save(){
      if(this.categoryForm.invalid) return;
      Object.assign(this.category, this.categoryForm.value);
      console.log(this.category);
      this.categorySrv.create(this.category)
      .subscribe({
        next:r=>{
          this.notifySrv.message('Data saved', 'DISMISS');
          this.category={};
          this.categoryForm.reset();
          this.categoryForm.markAsPristine();
          this.categoryForm.markAsUntouched();
        },
        error: err=>{
          this.notifySrv.message('Data save failed', 'DISMISS');
        }
      })

    }
    ngOnInit(): void {
      this.addProduct()
    }
}
