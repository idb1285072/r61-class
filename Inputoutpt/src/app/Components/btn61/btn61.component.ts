import { Component, EventEmitter, Input, Output } from '@angular/core';

@Component({
  selector: 'app-btn61',
  imports: [],
  templateUrl: './btn61.component.html',
  styleUrl: './btn61.component.css'
})
export class Btn61Component {
@Output() btnclickEvent= new EventEmitter ()
@Input() btnText:string="";
msg:string="Message from child.We are fine."
OnClick(){
 
  this.btnclickEvent.emit(this.msg);
}
}
