import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { OffresComponent } from './pages/offres/offres.component';
import { AproposComponent } from './pages/apropos/apropos.component';
import { GalerieComponent } from './pages/galerie/galerie.component';
import { AdminComponent } from './pages/admin/admin.component';
import { ContactComponent } from './pages/contact/contact.component';

const routes: Routes = [
  {path:'offres',component: OffresComponent},
  {path: 'apropos',component: AproposComponent},
  {path: 'galerie',component:GalerieComponent},
  {path:'admin',component: AdminComponent},
  {path: 'contact',component: ContactComponent}
]

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
