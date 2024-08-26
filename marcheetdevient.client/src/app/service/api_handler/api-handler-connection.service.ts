import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Login } from 'app/interface/login';
import { Register } from 'app/interface/register';

@Injectable({
  providedIn: 'root'
})
export class ApiHandlerConnectionService {
httpClient = inject(HttpClient);

async connectionRequete(utilisateur : Login){
  this.httpClient.post(`https://localhost:7260/api/AuthentificationControlleur/Connection`, {
    "mailUtilisateur": utilisateur.email,
    "motDePasse": utilisateur.motDePasse,
  }).subscribe((res: any) => {
    if (res.result) {
      alert("connection Reussi")
    } else {
      alert(res.mess)
    }
  })
}

async inscriptionRequete(utilisateur : Register){
  console.log(`le mail de l'utilisateur = ${utilisateur.email}`);
  this.httpClient.post(`https://localhost:7260/api/AuthentificationControlleur/Inscription`, {
    "mailUtilisateur": utilisateur.email,
    "prenomUtilisateur": utilisateur.prenom,
    "nomUtilisateur": utilisateur.nom,
    "motDePasse": utilisateur.motDePasse,
    "ageUtilisateur": utilisateur.age,
    "nTelephoneUtilisateur": utilisateur.telephone,
  }).subscribe((res: any) => {
    if (res.message) {
      console.log('Réponse reçue:', Response)
      alert("Inscription Reussi");
    } else {
      alert(res.error)
    }
  })
}
}
