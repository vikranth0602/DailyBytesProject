import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { Router } from '@angular/router';

import { BookmarkResponseModel }
  from '../../models/bookmark/bookmark.model';

import { UserModel }
  from '../../models/user/user.model';

import { ApiResponse }
  from '../../models/shared/api-response.model';

import { BookmarkService }
  from '../../services/bookmark.service';

import { NotificationService }
  from '../../services/notification.service';

import { AuthService }
  from '../../services/auth';

@Component({
  selector: 'app-bookmarks',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './bookmarks.html',
  styleUrls: ['./bookmarks.css']
})
export class BookmarksComponent
  implements OnInit {
  bookmarks: BookmarkResponseModel[] = [];

  user!: UserModel;

  isLoading = true;

  constructor(
    private bookmarkService: BookmarkService,
    private notify: NotificationService,
    private auth: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {
    const user =
      this.auth.getCurrentUser();

if (!user)
{
  this.notify.error(
    'User not found'
  );

  this.isLoading = false;

  return;
}

this.user = user;

this.loadBookmarks();

  }

  loadBookmarks(): void {
    this.isLoading = true;


this.bookmarkService
  .getBookmarks(this.user.id)
  .subscribe({

    next: (
      res: ApiResponse<BookmarkResponseModel[]>
    ) =>
    {
      this.bookmarks =
        res.data || [];

      this.isLoading = false;
    },

    error: (err: unknown) =>
    {
      console.log(err);

      this.isLoading = false;

      this.notify.error(
        'Failed to load bookmarks'
      );
    }
  });


  }

  readArticle(id: number): void {
    this.router.navigate([ '/articles', id ]);
  }
}
