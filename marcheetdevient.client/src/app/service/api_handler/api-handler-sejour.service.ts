import { HttpClient, HttpResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Sejour } from '../../interface/sejour'; //Import de l'interface des Sejours


@Injectable({
    providedIn: 'root',
})
export class ApiHandlerSejourService {
    private endPointUrl: string = "https://localhost:7260/api/Sejour"               //On va attribuer la route d'acc�s aux sejours via l'API

    httpClient = inject(HttpClient);

    recupererSejourList(): Observable<Sejour[]> {                                   //Fonction qui permet de r�cuperer la liste des sejours         
        let listfetched = this.httpClient.get<Sejour[]>(`${this.endPointUrl}`);     //On place dans un liste les �l�ments "S�jours" trouv� dans le endpoint
        return listfetched;                                                         //On retourne la liste
    }

    recupererSejourParId(id: number): Observable<Sejour> {                          //Fonction qui permet de rechercher les sejours en fonction de leurs identifiants
        return this.httpClient.get<Sejour>(`${this.endPointUrl}/${id}`);            //Retourne l'element sejour ayant pour Id celui rentr�
    }

    
    async ajoutSejour(sejour: Sejour) {                                              //Fonction d'ajout d'un sejour
        this.httpClient.post(`${this.endPointUrl}`, {                               //On initialise l'ajour � la BDD
            "nomSejour": sejour.nomSejour,                                         //On ajoute le nom au sejour
            "descriptifSejour": sejour.descriptifSejour,                                 //On ajoute un descriptif au sejour
            "lieuDepartSejour": sejour.lieuDepartSejour,                                //On ajoute un lieu de d�part au sejour
            "dateDebutSejour": sejour.dateDebutSejour.getDate,                                  //On ajoute une date de d�but au sejour
            "dateFinSejour": sejour.dateFinSejour.getDate,                                      //On ajoute une date de fin au sejour
            "nomLieuSejour": sejour.nomLieuSejour,                                    //On ajoute un lieu au sejour
            "prixSejour": sejour.prixSejour,                                             //On ajoute un prix au sejour
            "minParticipantSejour": sejour.minParticipantSejour,                        //On ajoute le nombre de participant min au sejour
            "maxParticipantSejour": sejour.maxParticipantSejour,                         //On ajoute le nombre de participant max au sejour
        }).subscribe((res: any) => {
            if (res.result) {
                alert("Sejour ajouter a l'appli")                                   //Message qui valide l'ajout du sejour dans la BDD 
            } else {
                alert(res.message)                                                  //Message d'erreur si l'ajout n'as pas p� �tre �ffectu�
            }
        })
        //debugger;
    }

    supprimerSejour(id: number): boolean {                                          //Fonction pour la suppression d'un sejour en fonction de son ID
        try {
            this.httpClient.delete(`${this.endPointUrl}/${id}`)                     //On supprime le sejour en fonction de l'id
            return true;                                                            //Suppression r�ussi
        } catch (error) {                                                           
            return false;                                                           //Suppression �chou�
        }
    }

    majSejour(id: number, sejour: Sejour) {                                         //Fonction de modification d'un sejour
        try {
            this.httpClient.put(`${this.endPointUrl}/${id}`, {                      //On recherche le sejour en fonction de son ID
                "idPhoto": null,
                "nomSejour": sejour.nomSejour,                                     //On modifie le nom au sejour
                "descriptifSejour": sejour.descriptifSejour,                             //On modifie un descriptif au sejour
                "lieuDepartSejour": sejour.lieuDepartSejour,                            //On modifie un lieu de d�part au sejour
                "dateDebutSejour": sejour.dateDebutSejour,                              //On modifie une date de d�but au sejour
                "dateFinSejour": sejour.dateFinSejour,                                  //On modifie une date de fin au sejour
                "nomLieuSejour": sejour.nomLieuSejour,                                //On modifie un lieu au sejour
                "prixSejour": sejour.prixSejour,                                         //On modifie un prix au sejour
                "minParticipantSejour": sejour.minParticipantSejour,                    //On modifie le nombre de participant min au sejour
                "maxParticipantSejour": sejour.maxParticipantSejour,                     //On modifie le nombre de participant max au sejour
            })
        } catch (error) {                                                           //Message d'erreur si modification �chou�

        }
    }
    getData(): Observable<HttpResponse<any>> {                                      //Fonction de r�cup�ration des donn�es suite � la requ�te
        return this.httpClient.get<any>(this.endPointUrl, { observe: 'response' }); //Retourne la r�ponse de la requ�te
    }
}
