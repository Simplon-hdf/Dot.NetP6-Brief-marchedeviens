import { HttpClient, HttpResponse } from '@angular/common/http';
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

  
  async ajoutPhoto(image: Photo) {
    this.httpClient.post(`${this.endPointUrl}`, {
      "datePhoto":  image.datePhoto,
      "estPubliquePhoto": image.estPubliquePhoto,
      "donneePhoto": image.donneePhoto,
      "idSejour": image.idSejour
    }).subscribe((res: any) => {
      if (res.result) {
        alert("Photo ajouter a l'appli")
      } else {
        alert(res.message)
      }
    })
    //debugger;
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
  getData(): Observable<HttpResponse<any>> {
    return this.httpClient.get<any>(this.endPointUrl, { observe: 'response' });
  }
}
