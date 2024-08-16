import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OffresComponent } from './pages/offres/offres.component';
import { AnnonceComponent } from './pages/annonce/annonce.component';
import { ReservationComponent } from './pages/reservation/reservation.component';
import { MarcheEtDeviensComponent } from './pages/marche-et-deviens/marche-et-deviens.component';
import { AproposComponent } from './pages/apropos/apropos.component';
import { AdminComponent } from './pages/admin/admin.component';
import { GalerieComponent } from './pages/galerie/galerie.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ActusComponent } from './pages/actus/actus.component';


const routes: Routes = [
  {path:'offres',component: OffresComponent},
  {path:'detail_offre',component: AnnonceComponent},
  {path:'reservation',component: ReservationComponent},
  {path:'marcheDeviens',component: MarcheEtDeviensComponent},
  {path:'apropos',component: AproposComponent},
  {path:'admin',component: AdminComponent},
  {path:'galerie',component: GalerieComponent},
  {path:'contact',component: ContactComponent},
  {path:'actu',component: ActusComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
