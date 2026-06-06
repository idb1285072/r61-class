import { Component } from '@angular/core';

@Component({
  selector: 'app-tax',
  templateUrl: './tax.component.html',
  styleUrl: './tax.component.css'
})
export class TaxComponent {
  taxes=[
    {value:500, rate:12},
    {value:700, rate:32},
    {value:900, rate:20},
    {value:300, rate:15},
    {value:800, rate:18},
    {value:800, rate:12},
    {value:1200, rate:14},
    {value:600, rate:12},
    {value:3500, rate:13},
    {value:500, rate:12},
    {value:2200, rate:14},
    {value:500, rate:12}
  ];

  taxRate:number=0;
}
