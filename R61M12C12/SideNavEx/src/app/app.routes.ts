import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { ProductsComponent } from './Components/products/products.component';
import { CategoryComponent } from './Components/category/category.component';

export const routes: Routes = [

    {path:"", component:HomeComponent},
    {path:"p", component:ProductsComponent},
    {path:"c", component:CategoryComponent},
];
