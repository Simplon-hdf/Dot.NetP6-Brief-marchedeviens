import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-reservation',
  templateUrl: './reservation.component.html',
  styleUrl: './reservation.component.css'
})
export class ReservationComponent {

  constructor(private router: Router) {}

  allerContact(): void {
    this.router.navigate(['contact']);
  }

  allerDetails(): void {
    this.router.navigate(['annonce']);
  }
}
