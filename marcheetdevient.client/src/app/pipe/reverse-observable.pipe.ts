import { Pipe, PipeTransform } from '@angular/core';
import { map, Observable } from 'rxjs';

@Pipe({
  name: 'reverseObservable',
})
export class ReverseObservablePipe implements PipeTransform {
  // fonction de reverse pour les observable
  transform(obs: Observable<any[]>): Observable<any[]> {
    return obs.pipe(map(arr => arr.slice().reverse()));
  }
}
