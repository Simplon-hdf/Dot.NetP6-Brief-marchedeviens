import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../../interface/photo';


@Injectable({
  providedIn: 'root',
})
export class ApiHandlerPhotoService {
  private endPointUrl: string = "https://localhost:7260/api/Photo"

  httpClient = inject(HttpClient);
  
  recupererPhotoList(): Observable<Photo[]>{
    let listfetched = this.httpClient.get<Photo[]>(`${this.endPointUrl}`);
    return listfetched;
  }

  recupererPhotoParId(id: number): Observable<Photo>{
    return this.httpClient.get<Photo>(`${this.endPointUrl}/${id}`);
  } 

  ajoutPhoto(image: Photo): boolean{
    try {
      let date: string[] = image.date.toDateString().split(',');
      date = date[1].split('/');
      this.httpClient.post(`${this.endPointUrl}`,{
        "idPhoto": null,
        "datePhoto": {
          "year": date[3],
          "month": date[1],
          "day": date[0],
          "dayOfWeek": 0,
          "dayOfYear": 0,
          "dayNumber": 0
        },
        "estPubliquePhoto": image.estPublique,
        "donneePhoto": image.donnee,
        "idSejour": image.idSejour
      })
    } catch (error) {
      return false
    }
    finally{
      return true
    }

  }
}
