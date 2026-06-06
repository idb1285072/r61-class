import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';

@Component({
  selector: 'app-ngclas-ex1',
  imports: [CommonModule],
  templateUrl: './ngclas-ex1.component.html',
  styleUrl: './ngclas-ex1.component.css'
})
export class NgclasEx1Component {
students:string[]=[
 "Tamim","Kamal","Jamal"
]
pi: number = 3.14159265359;
selectedItem:string=""
Amount=456321;
}
