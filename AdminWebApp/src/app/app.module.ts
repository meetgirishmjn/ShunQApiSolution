import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LayoutComponent } from './_Layouts/DefaultLayout/layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { StoreSearchComponent } from './components/stores/storeSearch.component';

@NgModule({
  declarations: [
    AppComponent,LayoutComponent,DashboardComponent,StoreSearchComponent  
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
