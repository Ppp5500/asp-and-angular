import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

// Angular Material modules
import { AngularMaterialModule } from './angular-material.module';

// Custom modules
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { HomeComponent } from './home/home.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { CitiesComponent } from './cities/cities.component';
import { RouteTestComponent } from './route-test/route-test.component';
import { JumsimComponent } from './jumsim/jumsim.component';
import { WebgpuComponent } from './webgpu/webgpu.component';
import { ProductListComponent } from './product-list/product-list.component';
import { ProductAlertsComponent } from './product-alerts/product-alerts.component';
import { CountriesComponent } from './countries/countries.component';
import { HtmlDoodlesComponent } from './html-doodles/html-doodles.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavMenuComponent,
    RouteTestComponent,
    JumsimComponent,
    CitiesComponent,
    WebgpuComponent,
    ProductListComponent,
    ProductAlertsComponent,
    CountriesComponent,
    HtmlDoodlesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    AngularMaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
