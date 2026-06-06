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
  onSubmit(f:any){
    console.log(this.category)
    this.srv.Save(this.category).subscribe({
      next:(res)=>{
        console.log(res)
       this.loadCategory()
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
}
