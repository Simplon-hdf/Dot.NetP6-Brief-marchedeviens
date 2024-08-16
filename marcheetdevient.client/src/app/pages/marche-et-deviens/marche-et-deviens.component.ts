import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-marche-et-deviens',
  templateUrl: './marche-et-deviens.component.html',
  styleUrl: './marche-et-deviens.component.css'
})
export class MarcheEtDeviensComponent {

  constructor(private router: Router) {}
  
  allerOffres(): void {
    this.router.navigate(['offres']);
  }

  allerAPropos(): void {
    this.router.navigate(['apropos']);
  }
  

}
