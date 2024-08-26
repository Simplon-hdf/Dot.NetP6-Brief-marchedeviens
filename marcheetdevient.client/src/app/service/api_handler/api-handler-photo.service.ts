import { HttpClient, HttpErrorResponse, HttpResponse } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable, catchError, map , of } from 'rxjs';
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
        alert(res.mess + "test")
      }
    })
    //debugger;
  }

  async supprimerPhoto(id: number) {
    await this.httpClient.delete(`${this.endPointUrl}/${id}`)
        .subscribe((res: any) => {
          if(res == null){
            alert("supression reussie")
          }
          else{
            alert("supression non resolu")
          }
        });
        
  }

  majPhoto(id: number,image: Photo){
      this.httpClient.put(`${this.endPointUrl}/${id}`,{
        "datePhoto": image.datePhoto,
        "estPubliquePhoto": image.estPubliquePhoto,
        "donneePhoto": image.donneePhoto,
        "idSejour": image.idSejour
      }).subscribe((res: any) => {
        if (res.result) {
          alert("Photo modifier dans l'appli")
        } else {
          alert(res.message)
        }
      })
  }
  getData(): Observable<HttpResponse<any>> {
    return this.httpClient.get<any>(this.endPointUrl, { observe: 'response' });
  }
}
