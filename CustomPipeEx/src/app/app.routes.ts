import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CategoryComponent } from './Components/category/category.component';
import { ProductComponent } from './Components/product/product.component';

export const routes: Routes = [
    {path:"",component:HomeComponent},
    {path:"cat",component:CategoryComponent},
    {path:"prd",component:ProductComponent}
];
