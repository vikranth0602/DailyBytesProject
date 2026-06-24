import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ApiResponse }
  from '../models/shared/api-response.model';

import { CommentModel }
  from '../models/comment/comment.model';

import { CommentRequestModel }
  from '../models/comment/comment-request.model';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class CommentService {


  private baseUrl = `${environment.apiUrl}/comment`;

  constructor(
    private http: HttpClient
  ) { }

  getComments(
    articleId: number
  ):
    Observable<ApiResponse<CommentModel[]>> {
    return this.http.get<
      ApiResponse<CommentModel[]>
    >(
      `${this.baseUrl}/${articleId}`
    );
  }

  addComment(
    data: CommentRequestModel
  ):
    Observable<ApiResponse<null>> {
    return this.http.post<
      ApiResponse<null>
    >(
      this.baseUrl,
      data
    );
  }

  deleteComment(
    id: number
  ):
    Observable<ApiResponse<null>> {
    return this.http.delete<
      ApiResponse<null>
    >(
      `${this.baseUrl}/${id}`
    );
  }
}
