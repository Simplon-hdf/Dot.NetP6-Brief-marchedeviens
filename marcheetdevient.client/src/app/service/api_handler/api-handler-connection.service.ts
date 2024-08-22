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
  this.httpClient.post(`https://localhost:7260/api/login?mailUtilisateur=${utilisateur.email}&motDePasse=${utilisateur.motDePasse}`, {
  }).subscribe((res: any) => {
    if (res.result) {
      alert("Photo ajouter a l'appli")
    } else {
      alert(res.mess)
    }
  })
}

async inscriptionRequete(utilisateur : Register){
  console.log(`le mail de l'utilisateur = ${utilisateur.email}`);
  this.httpClient.post(`https://localhost:7260/register?Mail=${utilisateur.email}&Prenom=${utilisateur.prenom}&Nom=${utilisateur.nom}&Mdp=${utilisateur.motDePasse}&Age=${utilisateur.age}&Telephone=${utilisateur.telephone}`, {
  }).subscribe((res: any) => {
    if (res.result) {
      alert("Photo ajouter a l'appli");
    } else {
      alert(res.mess)
    }
  })
}
}
