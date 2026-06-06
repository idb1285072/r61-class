import { Component } from '@angular/core';
import { SaleService } from '../../Services/sale.service';
import { Sale } from '../../Models/sale.model';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-display',
  imports: [CommonModule,RouterModule],
  templateUrl: './display.component.html',
  styleUrl: './display.component.css'
})
export class DisplayComponent {
  constructor(public sSrv:SaleService){}
  detail: Sale[]=[]
  
    ngOnInit(): void {
      this.loadSale()
    }
    delete(id:number){
      debugger;
      this.sSrv.Delete(id).subscribe({
        next:(res)=>{
          console.log(res)
         this.loadSale()
        },
        error:(er)=>{
          console.log(er)
        }
      })
    }
    loadSale(){
        this.sSrv.Get().subscribe({
          next:(res)=>{
            console.log(res)
            this.detail=res;
          },
          error:(er)=>{
            console.log(er)
          }
        })
    }
}
