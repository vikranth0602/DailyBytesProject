import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs';

import { UserModel } from '../models/user/user.model';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  private currentUserSubject =
    new BehaviorSubject<UserModel | null>(
      this.getStoredUser()
    );

  currentUser$ =
    this.currentUserSubject.asObservable();

  login(user: UserModel): void {

    localStorage.setItem(
      'user',
      JSON.stringify(user)
    );

    this.currentUserSubject.next(user);
  }

  logout(): void {

    localStorage.removeItem('user');

    this.currentUserSubject.next(null);
  }

  getCurrentUser(): UserModel | null {

    return this.currentUserSubject.value;
  }

  private getStoredUser():
    UserModel | null {

    const user =
      localStorage.getItem('user');

    return user
      ? JSON.parse(user)
      : null;
  }

  isLoggedIn(): boolean {

    return !!this.currentUserSubject.value;
  }
}
