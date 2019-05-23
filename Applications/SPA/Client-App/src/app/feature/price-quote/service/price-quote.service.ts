import { Injectable } from '@angular/core';
import { AuthHttpService } from 'src/app/share/services/auth-http.service';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class PriceQuoteService {

  constructor(
    private _apiHttp: AuthHttpService
  ) { }

  public getDrawing(): Observable<any> {
    return this._apiHttp.get('');
  }
}
