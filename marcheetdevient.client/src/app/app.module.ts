import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
import { AdminComponent } from './pages/admin/admin.component';
import { AproposComponent } from './pages/apropos/apropos.component';
import { GalerieComponent } from './pages/galerie/galerie.component';

@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
    AdminComponent,
    AproposComponent,
    GalerieComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
