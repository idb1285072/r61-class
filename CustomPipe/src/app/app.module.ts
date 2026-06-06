import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { TitlePipePipe } from './pipes/title-pipe.pipe';
import { AddTaxPipe } from './pipes/add-tax.pipe';
import { HomeComponent } from './Components/home/home.component';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { TaxComponent } from './Components/tax/tax.component';

@NgModule({
  declarations: [
    AppComponent,
    TitlePipePipe,
    AddTaxPipe,
    HomeComponent,
    NotFoundComponent,
    TaxComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideClientHydration()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
