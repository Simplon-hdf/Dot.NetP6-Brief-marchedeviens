import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
<<<<<<< HEAD
import { AproposComponent } from './pages/apropos/apropos.component';
import { GalerieComponent } from './pages/galerie/galerie.component';
=======
import { AdminComponent } from './pages/admin/admin.component';
import { PhotocommandeBoxComponent } from './pages/admin/admin-component/photocommande-box/photocommande-box.component';
import { ApiHandlerPhotoService } from './service/api_handler/api-handler-photo.service';
import { provideHttpClient } from '@angular/common/http';
>>>>>>> 6b28513e1dc508b3ddc556c93e2f478d16a0ab3e

@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
<<<<<<< HEAD
    AproposComponent,
    GalerieComponent
=======
>>>>>>> 6b28513e1dc508b3ddc556c93e2f478d16a0ab3e
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    AdminComponent,
    PhotocommandeBoxComponent,
  ],
  providers: [ApiHandlerPhotoService,provideHttpClient()],
  bootstrap: [AppComponent]
})
export class AppModule { }
