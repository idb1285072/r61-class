import { Routes } from '@angular/router';
import { SaleComponent } from './Componnets/sale/sale.component';
import { DisplayComponent } from './Components/display/display.component';

export const routes: Routes = [
    

    {path:"sale/:id",component:SaleComponent},
    {path:"",component:SaleComponent},
    {path:"saleDp",component:DisplayComponent}
];
