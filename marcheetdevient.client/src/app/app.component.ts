import { HttpClient } from '@angular/common/http';
import { Component, inject, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Register } from './interface/register';
import { ApiHandlerConnectionService } from './service/api_handler/api-handler-connection.service';
import { Login } from './interface/login';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})

export class AppComponent {
  constructor(private router: Router) { }
  apiHandlerConnection = inject(ApiHandlerConnectionService);

  allerPage(nomPage: string): void {
    this.router.navigate([`${nomPage}`]);
  }
  //variable de formulaire de login / register
    registerId: string = ""  ;
    registerMail: string = "" ;
    registerPrenom: string = "" ;
    registerNom: string = "" ;
    registerMDP: string = "" ;
    registerAge: number = 0;
    registerTelephone: number = 0;

    loginMail: string = "" ;
    loginMDP: string = "" ;

    envoieFormInscription(){
        let inscription : Register ={
            nom: this.registerNom,
            prenom: this.registerPrenom,
            email: this.registerMail,
            motDePasse: this.registerMDP,
            telephone: this.registerTelephone,
            age: this.registerAge,
        };
        this.apiHandlerConnection.inscriptionRequete(inscription);
    }

    envoieFormConnection(){
        let connection : Login={
            email: this.loginMail.replace('@',"%40"),
            motDePasse: this.loginMDP,
        };
        this.apiHandlerConnection.connectionRequete(connection)
        
    }
}

document.addEventListener("DOMContentLoaded", () => {
    let currentIndex = 0;
    const items = document.querySelectorAll(".carousel-item");

    function showItem(index: number) {
        items.forEach((item, i) => {
            if (i === index) {
                item.classList.add("active");
            } else {
                item.classList.remove("active");
            }
        });
    }

    document.getElementById("prev-btn")?.addEventListener("click", () => {
        currentIndex = (currentIndex > 0) ? currentIndex - 1 : items.length - 1;
        showItem(currentIndex);
    });

    document.getElementById("next-btn")?.addEventListener("click", () => {
        currentIndex = (currentIndex < items.length - 1) ? currentIndex + 1 : 0;
        showItem(currentIndex);
    });

    // Initial display
    showItem(currentIndex);
    });

    document.addEventListener("DOMContentLoaded", () => {
    const loginBtn = document.getElementById("login-btn") as HTMLElement;
    const loginPopup = document.getElementById("login-popup") as HTMLElement;
    const closePopupBtn = document.querySelector(".close-popup") as HTMLElement;
    const popupOverlay = document.getElementById("popup-overlay") as HTMLElement;

    const loginTab = document.getElementById("login-tab") as HTMLElement;
    const signupTab = document.getElementById("signup-tab") as HTMLElement;
    const loginForm = document.getElementById("login-form") as HTMLElement;
    const signupForm = document.getElementById("signup-form") as HTMLElement;
    const popupTitle = document.getElementById("popup-title") as HTMLElement;

    if (loginBtn && loginPopup && closePopupBtn && popupOverlay && loginTab && signupTab && loginForm && signupForm && popupTitle) {
        loginBtn.addEventListener("click", () => {
            loginPopup.style.display = "block";
            popupOverlay.style.display = "block";
        });

        closePopupBtn.addEventListener("click", () => {
            loginPopup.style.display = "none";
            popupOverlay.style.display = "none";
        });

        // Fermer la pop-up et l'overlay en cliquant à l'extérieur
        window.addEventListener("click", (event) => {
            if (event.target === popupOverlay) {
                loginPopup.style.display = "none";
                popupOverlay.style.display = "none";
            }
        });

        // Commutation entre Connexion et Inscription
        loginTab.addEventListener("click", () => {
            loginTab.classList.add("active");
            signupTab.classList.remove("active");
            loginForm.classList.add("active");
            signupForm.classList.remove("active");
            popupTitle.textContent = "Connexion";
        });

        signupTab.addEventListener("click", () => {
            signupTab.classList.add("active");
            loginTab.classList.remove("active");
            signupForm.classList.add("active");
            loginForm.classList.remove("active");
            popupTitle.textContent = "Créer un compte";
        });
    }
    });