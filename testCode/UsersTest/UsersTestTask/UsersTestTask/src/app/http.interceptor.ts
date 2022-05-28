import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpRequest, HttpHandler, HttpEvent } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../environments/environment';

@Injectable()
export class UsersHttpInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const newReq = req.clone({
      url: req.url.includes('config.json') ? req.url : "",//this.appSettings.baseApiUrl + req.url,
      params: req.params
    });

    return next.handle(newReq);
  }
}
