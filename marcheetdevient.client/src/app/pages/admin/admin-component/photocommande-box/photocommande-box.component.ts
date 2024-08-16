import { Component, OnInit } from '@angular/core';
import { ApiHandlerPhotoService } from '../../../../service/api_handler/api-handler-photo.service';
import { Photo } from '../../../../interface/photo';
import { CommonModule } from '@angular/common';
import {FormsModule} from '@angular/forms';

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

  public listPhoto!: Photo[];
  constructor(private apiHandlerPhoto: ApiHandlerPhotoService){}
  
  ngOnInit() {
    this.apiHandlerPhoto.recupererPhotoList().subscribe((data) => {this.listPhoto = data;console.log(data)});
    
  }

  ajoutPhoto(){
    let photoAjout: Photo = {
      idPhoto: null,
      datePhoto: this.postDatePhoto,
      donneePhoto: this.postLienPhoto,
      estPubliquePhoto: this.postEstPublique,
      idSejour:this.postIdSejour,
    }
    if(this.apiHandlerPhoto.ajoutPhoto(photoAjout)){
      alert("Photo ajouter")
    }
    else{
      alert("Photo non ajouter")
    }
    ;
    
    

  }
  
  
}
