import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './_Layouts/DefaultLayout/layout.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { StoreSearchComponent } from './components/stores/storeSearch.component';


const routes: Routes = [
  {
    path: 'home', component: LayoutComponent,
    children: [
      { path: '', redirectTo: '/home/dashboard', pathMatch: 'full' },
      { path: 'dashboard', component: DashboardComponent },
      { path: 'store/search', component: StoreSearchComponent },
    ]
  },
  //{ path: 'error', component: ErrorPageComponent },
  //{ path: 'notFound', component: PageNotFoundComponent },
  { path: '', redirectTo: '/home/dashboard', pathMatch: 'full' },
 // { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
