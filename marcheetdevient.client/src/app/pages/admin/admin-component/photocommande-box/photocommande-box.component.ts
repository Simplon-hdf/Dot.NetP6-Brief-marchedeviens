import { Component, OnInit } from '@angular/core';
import { ApiHandlerPhotoService } from '../../../../service/api_handler/api-handler-photo.service';
import { Observable } from 'rxjs';
import { Photo } from '../../../../interface/photo';
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-photocommande-box',
  standalone:true,
  imports: [CommonModule],
  templateUrl: './photocommande-box.component.html',
  styleUrl: './photocommande-box.component.css'
})
export class PhotocommandeBoxComponent implements OnInit {
  public listPhoto!: Photo[];
  constructor(private apiHandlerPhoto: ApiHandlerPhotoService){}
  
  ngOnInit() {
    this.apiHandlerPhoto.recupererPhotoList().subscribe((data) => {this.listPhoto = data;});
  } 
  
  
}
