import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ContactComponent } from './contact/contact.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { EntryformComponent } from './entryform/entryform.component';
import { CategoriesComponent } from './categories/categories.component';

export const routes: Routes = [
    {
        path:"Home", component:HomeComponent
    },
    {
        path:"", component:HomeComponent
    },
    {
        path:"contact", component:ContactComponent
    },
    {
        path:"entry", component:EntryformComponent
    },
    {
        path:"cat", component:CategoriesComponent
    },
    
   
    {
        path:"employee", redirectTo:"/entry", pathMatch:'full'
    }
    ,
    {
        path:"**", component:NotFoundComponent
    }
];
