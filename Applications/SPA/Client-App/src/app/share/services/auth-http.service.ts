import { Injectable, isDevMode } from '@angular/core';
import { HttpHeaders, HttpClient, HttpParams } from '@angular/common/http';
import { appSetting } from '../../appSettings';
import { Observable, throwError } from 'rxjs';
import { catchError, finalize } from 'rxjs/operators';

@Injectable()
export class AuthHttpService {
    constructor(
        private _http: HttpClient
    ) { }

    private addTokenToHeader(): HttpHeaders {
        let header: HttpHeaders = new HttpHeaders();
        if (localStorage.length !== 0) {
            const key = localStorage.getItem('tokenKey');
            const currentKey = JSON.parse(key);
            header = header.append('Content-type', 'application/json');
            header = header.append('Authorization', `Baerer ${currentKey.access_token}`);
        }
        return header;
    }

    public getAbsoluteUrl(path: string): string {
        if (isDevMode()) {
            return appSetting.localAPIUrl + path;
        } else {
            return appSetting.prodAPIUrl + path;
        }
    }

    private subscribeForRequest(request: Observable<any>): Observable<any> {
        return request
            .pipe(catchError(res => {
                if (res.status === 500) {

                }
                return throwError(res);
            }))
            .pipe(finalize(() => {

            }));
    }

    private beforeSendRequest() {

    }

    public get(url: string): Observable<any> {
        this.beforeSendRequest();
        return this.subscribeForRequest(
            this._http.get(
                this.getAbsoluteUrl(url),
                { headers: this.addTokenToHeader() }
            )
        );
    }

    public post(url: string, body: any): Observable<any> {
        this.beforeSendRequest();
        return this.subscribeForRequest(
            this._http.post(
                this.getAbsoluteUrl(url),
                body,
                { headers: this.addTokenToHeader() }
            )
        );
    }

    public put(url: string, body: any): Observable<any> {
        this.beforeSendRequest();
        return this.subscribeForRequest(
            this._http.put(
                this.getAbsoluteUrl(url),
                body,
                { headers: this.addTokenToHeader() }
            )
        );
    }

    public path(url: string, body: any): Observable<any> {
        this.beforeSendRequest();
        return this.subscribeForRequest(
            this._http.patch(
                this.getAbsoluteUrl(url),
                body,
                { headers: this.addTokenToHeader() }
            )
        );
    }
}
