import { Component } from '@angular/core';
import {CommonModule, NgClass} from '@angular/common';
@Component({
  selector: 'app-ngclass-ex',
  imports: [CommonModule, NgClass],
  templateUrl: './ngclass-ex.component.html',
  styleUrl: './ngclass-ex.component.css'
})
export class NgclassExComponent {
  currentClass = 'highlight';
isActive: boolean=true;
isDisabled: boolean=false;
button="btn btn-primary"
isPrimary:boolean = true;

currentItem="Tamim"
  constructor(){
    console.log(this.isPrimary)
  }
togglePrimary() {
  console.log(this.isPrimary)
 this.isPrimary = !this.isPrimary;
 }
 setUppercaseName() {
  this.currentItem =  this.currentItem.toUpperCase();
}
targetName="Kayak";
getProductCount(){
  return 8;
}
getProduct(){
 return "Kayak";
}



}
