<<<<<<< HEAD
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
import { AdminComponent } from './pages/admin/admin.component';

@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
    AdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
=======
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { OffresComponent } from './pages/offres/offres.component';
import { AdminComponent } from './pages/admin/admin.component';
import { UserProfileComponent } from './user-profile/user-profile.component';
import { ContactComponent } from './contact/contact.component';
import { ActusComponent } from './actus/actus.component';

@NgModule({
  declarations: [
    AppComponent,
    OffresComponent,
    AdminComponent,
    UserProfileComponent,
    ContactComponent,
    ActusComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
>>>>>>> b278f52 (feat:page offre mokup)
