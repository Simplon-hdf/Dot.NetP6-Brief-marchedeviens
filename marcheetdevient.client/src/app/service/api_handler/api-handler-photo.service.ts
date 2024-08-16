import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, map } from 'rxjs';
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
        let responceFromPost: object = this.httpClient.post(`${this.endPointUrl}`,{
        "idPhoto": null,
        "datePhoto": image.datePhoto,
        "estPubliquePhoto": image.estPubliquePhoto,
        "donneePhoto": image.donneePhoto,
        "idSejour": image.idSejour
      }).pipe(map((Object) => {return{message:Object.message}}))

      console.log(responceFromPost);
      return true;
    } catch (error) {
      return false;
    }

  }

  suprimerPhoto(id: number): boolean{
    try {
      this.httpClient.delete(`${this.endPointUrl}/${id}`)
      return true;
    } catch (error) {
      return false;
    }
  }

  majPhoto(id: number,image: Photo){
    try {
      this.httpClient.put(`${this.endPointUrl}/${id}`,{
        "idPhoto": null,
        "datePhoto":image.datePhoto,
        "estPubliquePhoto": image.estPubliquePhoto,
        "donneePhoto": image.donneePhoto,
        "idSejour": image.idSejour
      })
    } catch (error) {
      
    }
  }
}
