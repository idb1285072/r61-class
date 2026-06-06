import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  students=[
    {name:"Murad", gender:"Male"},
    {name:"Raj", gender:"Male"},
    {name:"X", gender:"Male"},
    {name:"Raj", gender:"Male"},
    {name:"Z", gender:"Female"},
    {name:"Y", gender:"Male"}
  ]
}
