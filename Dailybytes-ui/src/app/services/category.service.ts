import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';

import { ApiResponse } from '../models/shared/api-response.model';

import { CategoryModel } from '../models/category/category.model';

import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})

export class CategoryService {

 
  private baseUrl = `${environment.apiUrl}/category`;

  constructor(
    private http: HttpClient
  ) { }

  getCategories():
    Observable<ApiResponse<CategoryModel[]>> {
    return this.http.get<
      ApiResponse<CategoryModel[]>
    >(
      this.baseUrl
    );
  }

}
