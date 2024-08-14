import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
import { AdminComponent } from './pages/admin/admin.component';
import { PhotocommandeBoxComponent } from './pages/admin/admin-component/photocommande-box/photocommande-box.component';
import { ApiHandlerPhotoService } from './service/api_handler/api-handler-photo.service';
import { provideHttpClient } from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
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
