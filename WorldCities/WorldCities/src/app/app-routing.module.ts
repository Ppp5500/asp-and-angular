import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RouteTestComponent } from './route-test/route-test.component';
import { JumsimComponent } from './jumsim/jumsim.component';
import { CitiesComponent } from './cities/cities.component';
import { CityEditComponent } from './cities/city-edit.component';
import { CountriesComponent } from './countries/countries.component';
import { WebgpuComponent } from './webgpu/webgpu.component';
import { ProductListComponent } from './product-list/product-list.component';
import { HtmlDoodlesComponent } from './html-doodles/html-doodles.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'cities', component: CitiesComponent },
  { path: 'city/:id', component: CityEditComponent },
  { path: 'city', component: CityEditComponent },
  { path: 'countries', component: CountriesComponent },
  { path: 'route-test', component: RouteTestComponent },
  { path: 'jumsim', component: JumsimComponent },
  { path: 'webgpu', component: WebgpuComponent },
  { path: 'product-list', component: ProductListComponent },
  { path: 'html-doodles', component: HtmlDoodlesComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
