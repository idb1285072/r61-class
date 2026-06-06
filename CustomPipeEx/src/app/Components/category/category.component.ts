import { Component, OnInit } from '@angular/core';
import { Category } from '../../Models/category.model';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { CategoriesService } from '../../Services/categories.service';

@Component({
  selector: 'app-category',
  imports: [CommonModule,FormsModule],
  templateUrl: './category.component.html',
  styleUrl: './category.component.css'
})
export class CategoryComponent implements OnInit {
  category: Category = new Category;
  isEdit=false
  categories!: Category[];
  constructor(private srv:CategoriesService){}
  ngOnInit(): void {
    this.loadCategory()
  }
  loadCategory(){
    this.srv.Get().subscribe({
      next:(res)=>{
        console.log(res)
        this.categories=res
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
  clearAll(){
    this.isEdit=false;
    this.category= new Category
  }
  Edit(id:number){
    this.isEdit=true;
    this.srv.GetbyId(id).subscribe({
      next:(res)=>{
        console.log(res)
        this.category=res
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
  Delete(id:number){
    this.srv.Delete(id).subscribe({
      next:(res)=>{
        console.log(res)
         this.loadCategory()
         this.clearAll()
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
  onSubmit(f:any){
    console.log(this.category)
    this.srv.Save(this.category).subscribe({
      next:(res)=>{
        console.log(res)
       this.loadCategory()
       this.clearAll()
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
  update(){
    console.log(this.category)
    this.srv.Update(this.category).subscribe({
      next:(res)=>{
        console.log(res)
       this.loadCategory()
       this.clearAll()
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
}
