import { Component } from '@angular/core';
import { HighlightDirective } from '../../Directive/highlight.directive';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Import FormsModule
@Component({
  selector: 'app-home',
  imports: [HighlightDirective,FormsModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
color:string="red";
}
