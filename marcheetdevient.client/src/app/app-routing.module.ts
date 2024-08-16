<<<<<<< HEAD
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OffresComponent } from './pages/offres/offres.component';
<<<<<<< HEAD
import { AproposComponent } from './pages/apropos/apropos.component';
import { GalerieComponent } from './pages/galerie/galerie.component';

const routes: Routes = [
  {path:'offres',component: OffresComponent},
  {path: 'apropos',component: AproposComponent},
  {path: 'galerie',component:GalerieComponent},
=======
import { AdminComponent } from './pages/admin/admin.component';

const routes: Routes = [
  {path:'offres',component: OffresComponent},
  {path:'admin',component: AdminComponent},
>>>>>>> 6b28513e1dc508b3ddc556c93e2f478d16a0ab3e
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
=======
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OffresComponent } from './pages/offres/offres.component';
import { ContactComponent } from './ContactComponent/contact.component';

const routes: Routes = [
  {path:'offres',component: OffresComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  ContactComponent,
  exports: [RouterModule]
})
export class AppRoutingModule { }
>>>>>>> b278f52 (feat:page offre mokup)
