import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
import { AproposComponent } from './pages/apropos/apropos.component';
import { GalerieComponent } from './pages/galerie/galerie.component';
import { AdminComponent } from './pages/admin/admin.component';
import { ContactComponent } from './pages/contact/contact.component';
import { ActusComponent } from './pages/actus/actus.component';
import { ApiHandlerPhotoService } from './service/api_handler/api-handler-photo.service';
import { provideHttpClient } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
    ContactComponent,
    ActusComponent,
    AproposComponent,
    GalerieComponent,
    ],
  imports: [
    BrowserModule,
    AppRoutingModule, 
    AdminComponent,
  ],
  providers: [ApiHandlerPhotoService,provideHttpClient()],
  bootstrap: [AppComponent ,]
})
export class AppModule { }
 
