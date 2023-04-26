import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RouteTestComponent } from './route-test/route-test.component';
import { JumsimComponent } from './jumsim/jumsim.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'route-test', component: RouteTestComponent },
  { path: 'jumsim', component: JumsimComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
