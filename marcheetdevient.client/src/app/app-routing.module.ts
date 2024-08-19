import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OffresComponent } from './pages/offres/offres.component';
import { AproposComponent } from './pages/apropos/apropos.component';
import { GalerieComponent } from './pages/galerie/galerie.component';
import { AdminComponent } from './pages/admin/admin.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ActusComponent } from './pages/actus/actus.component';
import { AnnonceComponent } from './pages/annonce/annonce.component';
import { MarcheEtDeviensComponent } from './pages/marche-et-deviens/marche-et-deviens.component';
import { ReservationComponent } from './pages/reservation/reservation.component';
import { ActusComponent } from './pages/actus/actus.component';
import { AnnonceComponent } from './pages/annonce/annonce.component';
import { MarcheEtDeviensComponent } from './pages/marche-et-deviens/marche-et-deviens.component';
import { ReservationComponent } from './pages/reservation/reservation.component';

const routes: Routes = [
  {path: 'offres',component: OffresComponent},
  {path: 'apropos',component: AproposComponent},
  {path: 'galerie',component:GalerieComponent},
  {path: 'admin',component: AdminComponent},
  {path: 'contact',component: ContactComponent},
  {path: 'actus',component: ActusComponent},
  {path: 'annonce',component: AnnonceComponent},
  {path: 'accueil',component: MarcheEtDeviensComponent},
  {path: 'reservation',component: ReservationComponent},
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }