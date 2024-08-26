import { Component, OnInit } from '@angular/core';
import { ApiHandlerPhotoService } from '../../../../service/api_handler/api-handler-photo.service';
import { Photo } from '../../../../interface/photo';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';
import { Observable , of} from 'rxjs';
@Component({
  selector: 'app-photocommande-box',
  standalone:true,
  imports: [CommonModule,FormsModule],
  templateUrl: './photocommande-box.component.html',
  styleUrl: './photocommande-box.component.css'
})
export class PhotocommandeBoxComponent implements OnInit {
  /*variable des form*/
  postLienPhoto: string = "";
  postDatePhoto: Date = new Date;
  postEstPublique: boolean = false;
  postSejourLier: number = 0;
  postIdSejour: number = 0;

  supprimerIdPhoto : number = 0;

  modifIdPhoto: number = 0;
  modifLienPhoto: string = "";
  modifDatePhoto: Date = new Date;
  modifEstPublique: boolean = false;
  modifSejourLier: number = 0;
  modifIdSejour: number = 0;

  public listPhoto: Observable<Photo[]> = of([]);
  constructor(private apiHandlerPhoto: ApiHandlerPhotoService){}
  
  ngOnInit() {
    this.apiHandlerPhoto.recupererPhotoList().subscribe((data) => {this.listPhoto = of(data);console.log(data)});
    
    this.apiHandlerPhoto.getData().subscribe({
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

  async ajoutPhoto(){
    let photoAjout: Photo = {
      idPhoto: null,
      datePhoto: this.postDatePhoto,
      donneePhoto: this.postLienPhoto,
      estPubliquePhoto: this.postEstPublique,
      idSejour:this.postIdSejour,
    }
    this.apiHandlerPhoto.ajoutPhoto(photoAjout);
  }
  async supprimerPhotoCommande() {
    this.apiHandlerPhoto.supprimerPhoto(this.supprimerIdPhoto);
  }
  async modifierPhoto(){
    let photoModif: Photo = {
      idPhoto: null,
      datePhoto: this.modifDatePhoto,
      donneePhoto: this.modifLienPhoto,
      estPubliquePhoto: this.modifEstPublique,
      idSejour:this.modifIdSejour,
    }
    this.apiHandlerPhoto.majPhoto(this.modifIdPhoto,photoModif);
  }
}