import { CommonModule, JsonPipe } from '@angular/common';
import { Component } from '@angular/core';
import { AddTitlePipe } from '../../PipeEx/add-title.pipe';
import { AddTaxPipe } from '../../PipeEx/add-tax.pipe';

@Component({
  selector: 'app-home',
  imports: [CommonModule,AddTitlePipe,AddTaxPipe],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  taxRate:number=0
  students=[
    {Name:"Jerin", Gender:"Female",Fee:5000},
    {Name:"Sumaya", Gender:"Female",Fee:4000},
    {Name:"Sajib", Gender:"Male",Fee:6500},
    {Name:"Hasib", Gender:"Male",Fee:5500}
  ]

}
