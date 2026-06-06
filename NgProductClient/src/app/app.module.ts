import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { NavBarComponent } from './components/common/nav-bar/nav-bar.component';

import { HomeComponent } from './components/common/home/home.component';
import { CategoryListComponent } from './components/category/category-list/category-list.component';
import { CategoryCreateComponent } from './components/category/category-create/category-create.component';
import { CategoryEditComponent } from './components/category/category-edit/category-edit.component';
import { HttpClient, HttpClientModule, provideHttpClient, withFetch } from '@angular/common/http';
import { CategoryService } from './services/category.service';
import { NotifyService } from './services/notify.service';
import { MatImportModule } from './modules/mat-import/mat-import.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ProductDialogComponent } from './components/category/product-dialog/product-dialog.component';

@NgModule({
  declarations: [
    AppComponent,
    NavBarComponent,
    HomeComponent,
    CategoryListComponent,
    CategoryCreateComponent,
    CategoryEditComponent,
    ProductDialogComponent
  ],
  imports: [
    BrowserModule,
    
    AppRoutingModule,
    MatImportModule,
    ReactiveFormsModule
  ],
  providers: [
    provideHttpClient(withFetch()),
    provideAnimationsAsync(), CategoryService, NotifyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
