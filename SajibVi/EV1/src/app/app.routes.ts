import { Routes } from '@angular/router';
import { ViewProductComponent } from './view-product/view-product.component';
import { AddProductComponent } from './add-product/add-product.component';

export const routes: Routes = [
  { path: '', component: ViewProductComponent },
  { path: 'Index', component: ViewProductComponent },
  { path: 'Add', component: AddProductComponent },
];
