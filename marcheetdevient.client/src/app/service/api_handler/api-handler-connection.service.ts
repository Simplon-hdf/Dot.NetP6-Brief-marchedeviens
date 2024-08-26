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
    console.log(res)
    if (res.idUtilisateur != 0 || res.idUtilisateur != null) {
      alert("connection Reussi")
    } else {
      alert(res.mess)
    }
  })
}

async inscriptionRequete(utilisateur : Register){
  try{
    this.httpClient.post(`https://localhost:7260/api/AuthentificationControlleur/Inscription`, {
      "mailUtilisateur": utilisateur.email,
      "prenomUtilisateur": utilisateur.prenom,
      "nomUtilisateur": utilisateur.nom,
      "motDePasse": utilisateur.motDePasse,
      "ageUtilisateur": utilisateur.age,
      "nTelephoneUtilisateur": utilisateur.telephone,
    }).subscribe((res: any) => {
      if (res = 'User registered successfully!') {
        alert("Inscription Reussi");
      } 
      else if(res.ok == false){
        alert("Inscription erreur")
      }
      else {
        alert("Inscription erreur")
      }
    })
  }
  catch{
    alert("Inscription erreur")
  }
  }
}
