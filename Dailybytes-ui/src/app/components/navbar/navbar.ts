import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { Router, RouterModule } from '@angular/router';

import { AuthService } from '../../services/auth';

import { UserModel } from '../../models/user/user.model';

@Component({
  selector: 'app-navbar',

  standalone: true,

  imports: [
    CommonModule,
    RouterModule
  ],

  templateUrl: './navbar.html',

  styleUrls: ['./navbar.css']
})

export class NavbarComponent
  implements OnInit {

  isLoggedIn = false;

  currentUser:
    UserModel | null = null;

  constructor(
    private auth: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.auth.currentUser$
      .subscribe(user => {

        this.currentUser = user;

        this.isLoggedIn = !!user;
      });
  }

  logout(): void {

    this.auth.logout();

    this.router.navigate(['/']);
  }
}
