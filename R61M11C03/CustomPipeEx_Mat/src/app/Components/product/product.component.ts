import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Product } from '../../Models/product.model';
import { Category } from '../../Models/category.model';
import { CategoriesService } from '../../Services/categories.service';
import { ProductService } from '../../Services/product.service';
import { environment } from '../../../environments/environment.development';

@Component({
  selector: 'app-product',
  imports: [CommonModule,FormsModule],
  templateUrl: './product.component.html',
  styleUrl: './product.component.css'
})
export class ProductComponent implements OnInit {
product:Product={
  id: 0,
  name: '',
  picture: '',
  catId: 0
}
apiImageUrl= environment.imageUrl
productlist:Product[]=[]
categorylist:Category[]=[]
isEdit=false
selectedFiles?: FileList;
previews: string[] = [];
selectFiles(event: any): void {
  this.selectedFiles = event.target.files;
  this.previews = [];

  if (this.selectedFiles && this.selectedFiles[0]) {
    const numberOfFiles = this.selectedFiles.length;
    for (let i = 0; i < numberOfFiles; i++) {
      const reader = new FileReader();
      reader.onload = (e: any) => {
        this.previews.push(e.target.result);
      };
      reader.readAsDataURL(this.selectedFiles[i]);
    }
  }
}
constructor(private catsrv:CategoriesService,
  private prdSrv:ProductService
){}
  ngOnInit(): void {
    this.loadCategory();
    this.loadProduct();
  }
  loadProduct(){
    this.prdSrv.Get().subscribe({
      next:(res)=>{
        console.log(res)
        this.productlist=res
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
 
loadCategory(){
  this.catsrv.Get().subscribe({
    next:(res)=>{
      console.log(res)
      this.categorylist=res
    },
    error:(er)=>{
      console.log(er)
    }
  })
}
clearAll(){
  this.isEdit=false;
  this.product= new Product
  this.previews = [];
}
Edit(id:number){
  this.isEdit=true;
  this.prdSrv.GetbyId(id).subscribe({
    next:(res)=>{
      console.log(res)
      this.product=res
    },
    error:(er)=>{
      console.log(er)
    }
  })
}
Delete(id:number){
  this.prdSrv.Delete(id).subscribe({
    next:(res)=>{
      console.log(res)
       this.loadProduct()
       this.clearAll()
    },
    error:(er)=>{
      console.log(er)
    }
  })
}
onSubmit( ){
  console.log(this.product)
  const formData: FormData = new FormData();
  
  if (this.selectedFiles) {
    const file: File | null = this.selectedFiles.item(0);
    if (file) {
      formData.append('logo', file);
    }
  }
  formData.append('id', this.product.id.toString()??"0");
  formData.append('name', this.product.name);
  formData.append('picPath', this.product.picture);
  formData.append('category', this.product.catId.toString());
//debugger;
  
  this.prdSrv.Save(formData).subscribe({
    next:(res)=>{
      console.log(res)
     this.loadProduct()
     
     this.clearAll()
    },
    error:(er)=>{
      console.log(er)
    }
  })
}
update(){
  console.log(this.product)
  const formData: FormData = new FormData();
  
  if (this.selectedFiles) {
    const file: File | null = this.selectedFiles.item(0);
    if (file) {
      formData.append('logo', file);
    }
  }
  formData.append('id', this.product.id.toString()??"0");
  formData.append('name', this.product.name);
  formData.append('picPath', this.product.picture);
  formData.append('category', this.product.catId.toString());
  this.prdSrv.Update(formData).subscribe({
    next:(res)=>{
      console.log(res)
     this.loadProduct()
     this.clearAll()
    },
    error:(er)=>{
      console.log(er)
    }
  })
}
}
