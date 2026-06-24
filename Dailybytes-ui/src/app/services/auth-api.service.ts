import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ApiResponse }
  from '../models/shared/api-response.model';

import { AuthResponseModel }
  from '../models/auth/auth-response.model';

import { LoginRequestModel }
  from '../models/auth/login-request.model';

import { RegisterRequestModel }
  from '../models/auth/register-request.model';

import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})

export class AuthApiService {

  

  private baseUrl = `${environment.apiUrl}/auth`;



  constructor(
    private http: HttpClient
  ) { }

  login(
    data: LoginRequestModel
  ):
    Observable<ApiResponse<AuthResponseModel>> {
    return this.http.post<
      ApiResponse<AuthResponseModel>
    >(
      `${this.baseUrl}/login`,
      data
    );
  }

  register(
    data: RegisterRequestModel
  ):
    Observable<ApiResponse<AuthResponseModel>> {
    return this.http.post<
      ApiResponse<AuthResponseModel>
    >(
      `${this.baseUrl}/register`,
      data
    );
  }
}
