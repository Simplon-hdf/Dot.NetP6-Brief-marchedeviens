import { Component} from '@angular/core';
import { PhotocommandeBoxComponent } from './admin-component/photocommande-box/photocommande-box.component';
import { SejourcommandeBoxComponent } from './admin-component/sejourcommande-box/sejourcommande-box.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-admin',
  standalone: true,
  templateUrl: './admin.component.html',
  imports:[PhotocommandeBoxComponent,CommonModule,SejourcommandeBoxComponent],
  styleUrl: './admin.component.css',
})
export class AdminComponent{
  public commandeSelected: string = "";
  constructor(){}

  public selectionCommande = (selectioner: string) => {
    this.commandeSelected = selectioner;
  }
  
}
