import { Component } from '@angular/core';

import { CommonModule } from '@angular/common';

import { Observable } from 'rxjs';

import {
  NotificationService,
  NotificationData
} from '../../services/notification.service';

@Component({
  selector: 'app-notification',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './notification.component.html',
  styleUrls: ['./notification.component.css']
})

export class NotificationComponent {

  notification$:
    Observable<NotificationData | null>;

  constructor(
    private notificationService:
      NotificationService
  ) {

    this.notification$ =
      this.notificationService.notification$;
  }

}
