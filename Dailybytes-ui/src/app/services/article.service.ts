import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ApiResponse } from '../models/shared/api-response.model';

import { ArticleListModel } from '../models/article/article-list.model';

import { ArticleDetailModel } from '../models/article/article-detail.model';

import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ArticleService {

 
  private baseUrl = `${environment.apiUrl}/article`;

  constructor( private http: HttpClient ) { }

  getArticles(): Observable<ApiResponse<ArticleListModel[]>>
  {
    return this.http.get< ApiResponse<ArticleListModel[]> >(this.baseUrl);
  }

  getArticleById( id: number): Observable<ApiResponse<ArticleDetailModel>>
  {
    return this.http.get< ApiResponse<ArticleDetailModel >>( `${this.baseUrl}/${id}` );
  }



}
