import { Component, OnInit } from '@angular/core';
import { ApiHandlerSejourService } from '../../../../service/api_handler/api-handler-sejour.service';
import { Sejour } from '../../../../interface/sejour';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
    selector: 'app-sejourcommande-box',
    standalone: true,
    imports: [CommonModule, FormsModule],
    templateUrl: './sejourcommande-box.component.html',
    styleUrl: './sejourcommande-box.component.css'
})
export class SejourcommandeBoxComponent implements OnInit {
    /*variable des form*/
    postNomSejour: string = "";
    postDescriptif: string = "";
    postLieuDepart: string = "";
    postDateDebut: Date = new Date;
    postDateFin: Date = new Date;
    postNomLieu: string = "";
    postPrix: number = 0;
    postNumPartMin: number = 0;
    postNumPartMax: number = 0;

    public listSejour!: Sejour[];

    constructor(private apiHandlerSejour: ApiHandlerSejourService) { }

    ngOnInit() {
        this.apiHandlerSejour.recupererSejourList().subscribe((data) => { this.listSejour = data; console.log(data) });

        this.apiHandlerSejour.getData().subscribe({
            next: (response) => {
                console.log('Status Code:', response.status);
                console.log('Headers:', response.headers);
                console.log('Body:', response.body);
            },
            error: (error) => {
                console.error('Error:', error);
            },
            complete: () => {
                console.log('Request complete');
            }
        });
    }

    async ajoutSejour() {
        let sejourAjout: Sejour = {
            idSejour: null,
            nomSejour: this.postNomSejour,
            descriptifSejour: this.postDescriptif,
            lieuDepartSejour: this.postLieuDepart,
            dateDebutSejour: this.postDateDebut,
            dateFinSejour: this.postDateFin,
            nomLieuSejour: this.postNomLieu,
            prixSejour: this.postPrix,
            minParticipantSejour: this.postNumPartMin,
            maxParticipantSejour: this.postNumPartMax,
            totalParticipantActuelSejour : null,
        }
        this.apiHandlerSejour.ajoutSejour(sejourAjout);
        alert(`reussite`)
    }
 }
