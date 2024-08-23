import { Component, inject } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'app/interface/login';
import { Register } from 'app/interface/register';
import { ApiHandlerConnectionService } from 'app/service/api_handler/api-handler-connection.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ApiHandlerSejourService } from 'app/service/api_handler/api-handler-sejour.service';
import {Observable, of,} from 'rxjs';
import { Sejour } from 'app/interface/sejour';
import { ReverseObservablePipe } from 'app/pipe/reverse-observable.pipe';

@Component({
  selector: 'app-marche-et-deviens',
  templateUrl: './marche-et-deviens.component.html',
  styleUrl: './marche-et-deviens.component.css',
  standalone: true,
  imports: [CommonModule, FormsModule],
})
export class MarcheEtDeviensComponent {
  constructor(private router: Router , private reverseObservale : ReverseObservablePipe) {}
  
  allerOffres(): void {
    this.router.navigate(['offres']);
  }

  allerAPropos(): void {
    this.router.navigate(['apropos']);
  }

  inverserListSejour(){
    let listRetournée = this.reverseObservale.transform(this.listSejour)
    return listRetournée
  }

  apiHandlerSejour = inject(ApiHandlerSejourService)
  public listSejour: Observable<Sejour[]> = of([]);
  
  public pourcentageDeBarreRemplie(max: number, personneInscrite: number| null):number{
    if(personneInscrite == null){
      return 100;
    }
    else{
      return 100 - (personneInscrite / max) * 100;
    }
  }
  
  ngOnInit() {
    this.apiHandlerSejour.recupererSejourList().subscribe((data) => { this.listSejour = of(data); console.log(data) });
    
  }

  
}
