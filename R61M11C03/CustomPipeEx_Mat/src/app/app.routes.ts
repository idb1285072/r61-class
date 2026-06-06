import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CategoryComponent } from './Components/category/category.component';
import { ProductComponent } from './Components/product/product.component';
import { MatexComponent } from './Components/matex/matex.component';

export const routes: Routes = [
    {path:"",component:HomeComponent},
    {path:"cat",component:CategoryComponent},
    {path:"prd",component:ProductComponent},
    {path:"Mat1",component:MatexComponent}
];
