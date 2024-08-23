import { Component, inject } from '@angular/core';
import { Sejour } from 'app/interface/sejour';
import { ApiHandlerSejourService } from 'app/service/api_handler/api-handler-sejour.service';
import { Observable, of } from 'rxjs';

@Component({
  selector: 'app-offres',
  templateUrl: './offres.component.html',
  styleUrl: './offres.component.css'
})
export class OffresComponent {
  apiHandlerSejour = inject(ApiHandlerSejourService)
  public listSejour: Observable<Sejour[]> = of([]);
  ngOnInit() {
    this.apiHandlerSejour.recupererSejourList().subscribe((data) => { this.listSejour = of(data); console.log(data) });
  }
}
