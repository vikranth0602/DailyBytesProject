import { Component } from '@angular/core';

import { RouterOutlet } from '@angular/router';

import { NavbarComponent }
  from './components/navbar/navbar';

// import { NotificationComponent }
//   from './components/notification/notification.component';
import { NotificationComponent } from '../app/components/notification/notification.component';


@Component({

  selector: 'app-root',

  standalone: true,

  imports: [
    RouterOutlet,
    NavbarComponent,
    NotificationComponent
  ],

  template: `

    <app-notification></app-notification>

    <app-navbar></app-navbar>

    <router-outlet></router-outlet>

  `
})

export class AppComponent { }
