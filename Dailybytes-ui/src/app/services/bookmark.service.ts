import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ApiResponse } from '../models/shared/api-response.model';

import { BookmarkRequestModel } from '../models/bookmark/bookmark-request.model';

import { BookmarkResponseModel } from '../models/bookmark/bookmark.model';

@Injectable({
  providedIn: 'root'
})

export class BookmarkService {

  private baseUrl =
    'https://localhost:7092/api/bookmark';

  constructor(
    private http: HttpClient
  ) { }

  addBookmark(
    data: BookmarkRequestModel
  ):
    Observable<ApiResponse<null>> {
    return this.http.post<
      ApiResponse<null>
    >(
      this.baseUrl,
      data
    );
  }

  removeBookmark(
    userId: number,
    articleId: number
  ):
    Observable<ApiResponse<null>> {
    return this.http.delete<
      ApiResponse<null>
    >(
      `${this.baseUrl}?userId=${userId}&articleId=${articleId}`
    );
  }

  getBookmarks(
    userId: number
  ):
    Observable<
      ApiResponse<BookmarkResponseModel[]>
    > {
    return this.http.get<
      ApiResponse<BookmarkResponseModel[]>
    >(
      `${this.baseUrl}/${userId}`
    );
  }
}
