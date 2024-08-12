import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Photo } from '../../interface/photo';

@Injectable({
  providedIn: 'root'
})
export class ApiHandlerPhotoService {
  private endPointUrl: string = "localHost:4200/api/"
  constructor(private http:HttpClient) {}
  getPhotoList(): Observable<Photo[]>{
    return this.http.get<Photo[]>(`${this.endPointUrl}photo`)
  }
}
