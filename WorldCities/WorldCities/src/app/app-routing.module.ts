import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RouteTestComponent } from './route-test/route-test.component';
import { JumsimComponent } from './jumsim/jumsim.component';
import { CitiesComponent } from './cities/cities.component';
import { WebgpuComponent } from './webgpu/webgpu.component';
import { ProductListComponent } from './product-list/product-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'cities', component: CitiesComponent },
  { path: 'route-test', component: RouteTestComponent },
  { path: 'jumsim', component: JumsimComponent },
  { path: 'webgpu', component: WebgpuComponent },
  {path: 'product-list', component: ProductListComponent}
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
