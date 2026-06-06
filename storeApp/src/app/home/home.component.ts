import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
 

@Component({
  selector: 'app-home',
  imports: [CommonModule,FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
title="Welcome to our site."
name="R61"
Submit(){
  console.log(this.name)
}
ChangeData(name:any){
  
console.log(name)
}
}
