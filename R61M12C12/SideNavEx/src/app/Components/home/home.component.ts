 
import { Component,ViewChild } from '@angular/core';
import { RouterLink, RouterOutlet } from '@angular/router';
 
import { MatSidenav, MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatListModule } from '@angular/material/list';
import { MatIconModule } from '@angular/material/icon';
import { CommonModule } from '@angular/common';
import { CategoryComponent } from '../category/category.component';
import { ProductsComponent } from '../products/products.component';
@Component({
  selector: 'app-home',
  imports: [RouterOutlet, MatSidenavModule,MatToolbarModule,
    MatListModule,MatIconModule,CommonModule,RouterLink, CategoryComponent,ProductsComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  // @ViewChild('sidenav') sidenav: MatSidenav | undefined;
  // isExpanded = true;
  // showSubmenu: boolean = false;
  // isShowing = false;
  // showSubSubMenu: boolean = false;

  // mouseenter() {
  //   if (!this.isExpanded) {
  //     this.isShowing = true;
  //   }
  // }

  // mouseleave() {
  //   if (!this.isExpanded) {
  //     this.isShowing = false;
  //   }
  // }
}
