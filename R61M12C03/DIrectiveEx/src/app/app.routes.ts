import { Routes } from '@angular/router';
import { NgclassExComponent } from './ngclass-ex/ngclass-ex.component';
import { NgclasEx1Component } from './ngclas-ex1/ngclas-ex1.component';

export const routes: Routes = [
    {path:"",component:NgclassExComponent},
    {path:"Ex1",component:NgclasEx1Component}
];
