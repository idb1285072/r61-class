import { Component } from '@angular/core';
import {MatDialog,MatDialogConfig} from '@angular/material/dialog';
import { SaleService } from '../../Services/sale.service';
import { AdddetailsComponent } from '../../Components/adddetails/adddetails.component';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Route, RouterModule,Router } from '@angular/router';
import { json } from 'node:stream/consumers';
 
@Component({
  selector: 'app-sale',
  imports: [FormsModule,CommonModule,RouterModule],
  templateUrl: './sale.component.html',
  styleUrl: './sale.component.css'
})
export class SaleComponent {
  selectedFiles?: FileList;
   id:string="";
  constructor(public dialog:MatDialog,public sSrv:SaleService,
    private route: ActivatedRoute,
    private router:Router
  ){}
  ngOnInit(): void {
   
    this.route.paramMap.subscribe((params)=>{
      this.id= params.get('id')! 
       
     });
     console.log(this.id)
    this.loadsale( )
  }
  loadsale( ){
    console.log(( this.id.toString()))

    this.sSrv.GetbyId(parseInt( this.id)).subscribe({
      next:(res)=>{
        this.sSrv.sale= res
        console.log(res)
       
      },
      error:(err)=>{

      }
    })
  }
  selectFiles(event: any): void {
    //debugger;
    this.selectedFiles = event.target.files;
    console.log(event.target.files)
    console.log(this.selectedFiles)
    if (this.selectedFiles && this.selectedFiles[0]) {
      const numberOfFiles = this.selectedFiles.length;
      for (let i = 0; i < numberOfFiles; i++) {
        const reader = new FileReader();
        reader.onload = (e: any) => {
           
        };
        reader.readAsDataURL(this.selectedFiles[i]);
      }
    }
  }
 
  onSubmit(){
    console.log(this.sSrv.sale)
    const formData: FormData = new FormData();
    console.log(this.selectedFiles)

    if (this.selectedFiles) {
      const file: File | null = this.selectedFiles.item(0);
      if (file) {
        formData.append('logo', file);
      }
    
    formData.append('orderdata', JSON.stringify( this.sSrv.sale ));
   
    if(this.sSrv.sale.id>0){
      this.sSrv.Update(formData).subscribe({
        next:(res)=>{
          console.log(res)
          this.router.navigate(['/saleDp']);
        },
        error:(er)=>{
          console.log(er)
        }
      })
    }
    else
    {
    this.sSrv.Save(formData).subscribe({
      next:(res)=>{
        console.log(res) 
        this.router.navigate(['/saleDp']);
      },
      error:(er)=>{
        console.log(er)
      }
    })
  }
  }
  else
  {
    alert("Please Provide Image")
  }

  }
  clearAll(){

  }
  addoreditItem(orderIndex?:any,did?:number){
    console.log("Index: "+orderIndex)
    console.log(did)
    const dialogconfig=new MatDialogConfig();
    dialogconfig.autoFocus=true;
    dialogconfig.disableClose=true;
    dialogconfig.width="50%";
    dialogconfig.data={
      orderIndex
    }
    this.dialog.open(AdddetailsComponent,dialogconfig).afterClosed().subscribe(res=>{
       
      })
 
  }
  deleteItem(id:number,index:number){
    this.sSrv.sale.details.splice(id,1)

  }
}
