import { Injectable } from '@angular/core';

import { BehaviorSubject } from 'rxjs';

export interface NotificationData {

  message: string;

  type: 'success' | 'error';

}

@Injectable({
  providedIn: 'root'
})

export class NotificationService {

  private notificationSubject =
    new BehaviorSubject<NotificationData | null>(null);

  notification$ =
    this.notificationSubject.asObservable();

  success(message: string): void {

    this.show(message, 'success');
  }

  error(message: string): void {

    this.show(message, 'error');
  }

  private show(
    message: string,
    type: 'success' | 'error'
  ): void {

    this.notificationSubject.next({
      message,
      type
    });

    setTimeout(() => {

      this.notificationSubject.next(null);

    }, 3000);
  }

}
