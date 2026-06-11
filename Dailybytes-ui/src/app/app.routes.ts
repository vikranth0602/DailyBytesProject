import { Routes } from '@angular/router';

import { HomeComponent } from './components/home/home';

import { SignUiComponent } from './components/sign-ui/sign-ui';

import { ArticlesComponent } from './components/articles/articles';

import { ReadArticleComponent } from './components/read-article/read-article';

import { BookmarksComponent } from './components/bookmarks/bookmarks';

import { authGuard } from './guards/auth-guard';

import { guestGuard } from './guards/guest-guard';



export const routes: Routes = [

  // PUBLIC

  {
    path: '',
    component: HomeComponent
  },

  {
    path: 'auth',
    component: SignUiComponent,
    canActivate: [guestGuard]
  },

  // PRIVATE

  {
    path: 'articles',
    component: ArticlesComponent,
    canActivate: [authGuard]
  },

  {
    path: 'articles/:id',
    component: ReadArticleComponent,
    canActivate: [authGuard]
  },


  {
    path: 'bookmarks',
    component: BookmarksComponent,
    canActivate: [authGuard]
  },

  {
    path: '**',
    redirectTo: ''
  }
];
