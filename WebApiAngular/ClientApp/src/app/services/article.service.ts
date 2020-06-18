import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Observable } from 'rxjs';
import { Article } from '../models/article';
import { catchError, tap } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class ArticleService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Article[]> {
    return this.http.get<Article[]>(this.baseUrl + 'api/Articles')
      .pipe(
        catchError(this.handleErrorService.handleError<Article[]>('Consulta Articulos', null))
      );
  }


  post(article: Article): Observable<Article> {
    return this.http.post<Article>(this.baseUrl + 'api/Articles', article)
      .pipe(
        catchError(this.handleErrorService.handleError<Article>('Registrar Articulo', null))
      );
  }

}
