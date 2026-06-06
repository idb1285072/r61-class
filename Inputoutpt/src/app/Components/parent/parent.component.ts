import { Component } from '@angular/core';
import { ChildComponent } from "../child/child.component";
import { CommonModule } from '@angular/common';
import { Btn61Component } from '../btn61/btn61.component';

@Component({
  selector: 'app-parent',
  imports: [ChildComponent,CommonModule,Btn61Component],
  templateUrl: './parent.component.html',
  styleUrl: './parent.component.css'
})
export class ParentComponent {
ParentMessage:string="Hurrah! We are dyanamic people";
txt:string="Save";
student=[
   {  Name:"Tamim", Hobby:"Riding"},
  {  Name:"Hasib", Hobby:"Sports"},
  {  Name:"Zerin", Hobby:"Reading"},
  {  Name:"Sumaya",Hobby:"sketching"},
]
stdarr=["Hasib","Kalam"]
childMag:string="";
GetData(event:string ){
 // debugger;
  console.log(event)
  this.childMag=event;
console.log("Clicked")
}
}
