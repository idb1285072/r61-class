import { Routes } from '@angular/router';
import { HomeComponent } from './Components/home/home.component';
import { CategoryComponent } from './Components/category/category.component';
import { ProductComponent } from './Components/product/product.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { authGuard } from './guards/auth.guard';
import { SalesComponent } from './Components/sales/sales.component';
 

export const routes: Routes = [
    {path:"",component:HomeComponent},
    {path:"cat",component:CategoryComponent,canActivate:[authGuard]},
    {path:"prd",component:ProductComponent},
    {path:"reg",component:RegisterComponent},
    {path:"login",component:LoginComponent},
    {path:"sale",component:SalesComponent}
];
