import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
import { AproposComponent } from './pages/apropos/apropos.component';
import { AnnonceComponent } from './pages/annonce/annonce.component';
import { ReservationComponent } from './pages/reservation/reservation.component';
import { MarcheEtDeviensComponent } from './pages/marche-et-deviens/marche-et-deviens.component';
import { GalerieComponent } from './pages/galerie/galerie.component';
import { AdminComponent } from './pages/admin/admin.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ActusComponent } from './pages/actus/actus.component';


@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
    AproposComponent,
    AnnonceComponent,
    ReservationComponent,
    MarcheEtDeviensComponent,
    GalerieComponent,
    ContactComponent,
    ActusComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminComponent,
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
