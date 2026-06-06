import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Sale } from '../../Models/sale.model';
import { CommonModule } from '@angular/common';
import { Customer } from '../../Models/customer.model';
import {MatDialog,MatDialogConfig} from '@angular/material/dialog'
import { AdddetailsComponent } from '../adddetails/adddetails.component';
import { SaleService } from '../../Services/sale.service';


@Component({
  selector: 'app-sales',
  imports: [FormsModule,CommonModule ],
  templateUrl: './sales.component.html',
  styleUrl: './sales.component.css'
})
export class SalesComponent {
  // sale: Sale = new Sale;
  custList:Customer[]=[]
  constructor(public dialog:MatDialog,public sSrv:SaleService){}
  onSubmit(){

  }
  clearAll(){

  }
  addoreditItem(){
    this.dialog.open(AdddetailsComponent)
  }
  deleteItem(id:number,index:number){}
}
