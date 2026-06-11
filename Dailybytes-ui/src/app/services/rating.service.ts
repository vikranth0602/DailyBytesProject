import { Injectable } from '@angular/core';

import {
  HttpClient,
  HttpHeaders
} from '@angular/common/http';

import {
  Observable
} from 'rxjs';

import {
  ApiResponse
} from '../models/shared/api-response.model';

import {
  RatingRequestModel
} from '../models/rating/rating-request.model';

import {
  UserModel
} from '../models/user/user.model';

@Injectable({
  providedIn: 'root'
})

export class RatingService {

  private baseUrl =
    'https://localhost:7092/api/rating';

  constructor(
    private http: HttpClient
  ) { }

  submitRating(
    data: RatingRequestModel
  ):
    Observable<ApiResponse<null>> {

    const user: UserModel | null =
      JSON.parse(
        localStorage.getItem('user') || 'null'
      );

    if (!user) {

      throw new Error(
        'User not found'
      );
    }

    const headers =
      new HttpHeaders({

        UserId:
          user.id.toString()

      });

    return this.http.post<
      ApiResponse<null>
    >(
      this.baseUrl,
      data,
      { headers }
    );
  }

  getAverageRating(
    articleId: number
  ):
    Observable<ApiResponse<number>> {

    return this.http.get<
      ApiResponse<number>
    >(
      `${this.baseUrl}/average/${articleId}`
    );
  }

}
