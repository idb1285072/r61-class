import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

@Component({
  selector: 'app-categories',
  imports: [ReactiveFormsModule,FormsModule,CommonModule],
  providers:[HttpClient],
  templateUrl: './categories.component.html',
  styleUrl: './categories.component.css'
})
export class CategoriesComponent  implements OnInit{

  category!:FormGroup
  categories:any

constructor( private client:HttpClient){}
ngOnInit(): void {
  this.loadCategory()
  this.initializrForm();
}
initializrForm(){
  this.category=new FormGroup(
    {
      Id:new FormControl(0),
      Name:new FormControl('',Validators.required),
      ParentCategory:new FormControl( ),
    }
  );
}
loadCategory(){
  this.client.get("https://localhost:7064/api/Categories")
              .subscribe(
                {
                    next:(data)=>{
                      console.log(data)
                      this.categories=data
                    },
                    error:(er)=>{
                      console.log(er)
                    }

                })
}
Submit(){
  console.log( this.category.value)
  this.Save()
}
Save(){
  this.client.post("https://localhost:7064/api/Categories", this.category.value)
              .subscribe(
                {
                    next:(data)=>{
                      console.log(data)
                     this.loadCategory()
                    },
                    error:(er)=>{
                      console.log(er)
                    }

                })
}

Edit(id:number){
  this.client.get("https://localhost:7064/api/Categories/"+id)
  .subscribe(
    {
        next:(data)=>{
          console.log(data)
          // this.category=new FormGroup(
          //   {
          //     Id:new FormControl(data.id),
          //     Name:new FormControl(data.name),
          //     ParentCategory:new FormControl( ),
          //   }
          // );
        },
        error:(er)=>{
          console.log(er)
        }

    })
}
delete(id:number){
  this.client.delete("https://localhost:7064/api/Categories/"+id)
  .subscribe(
    {
        next:(data)=>{
          console.log(data)
         this.loadCategory()
        },
        error:(er)=>{
          console.log(er)
        }

    })
}

}
