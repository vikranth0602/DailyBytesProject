import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import {
  Router,
  RouterModule
} from '@angular/router';

import {
  forkJoin,
  of
} from 'rxjs';

import { ArticleService }
  from '../../services/article.service';

import { CategoryService }
  from '../../services/category.service';

import { BookmarkService }
  from '../../services/bookmark.service';

import { NotificationService }
  from '../../services/notification.service';

import { AuthService }
  from '../../services/auth';

import { ArticleListModel }
  from '../../models/article/article-list.model';

import { CategoryModel }
  from '../../models/category/category.model';

import { BookmarkResponseModel }
  from '../../models/bookmark/bookmark.model';

import { ApiResponse }
  from '../../models/shared/api-response.model';

import { UserModel }
  from '../../models/user/user.model';

@Component({
  selector: 'app-articles',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  templateUrl: './articles.html',
  styleUrls: ['./articles.css']
})

export class ArticlesComponent
  implements OnInit {

  articles:
    (ArticleListModel & {
      isBookmarked: boolean
    })[] = [];

  filteredArticles:
    (ArticleListModel & {
      isBookmarked: boolean
    })[] = [];

  categories: CategoryModel[] = [];

  selectedCategory = '';

  user: UserModel | null = null;

  isLoading = true;

  bookmarkLoadingId: number | null = null;

  constructor(
    private articleService:
      ArticleService,


private categoryService:
  CategoryService,

private bookmarkService:
  BookmarkService,

private notify:
  NotificationService,

private auth:
  AuthService,

private router:
  Router


  ) { }

  ngOnInit(): void {


this.user =
  this.auth.getCurrentUser();

this.loadInitialData();


  }

  loadInitialData(): void {

  
this.isLoading = true;

forkJoin({

  articles:
    this.articleService
      .getArticles(),

  categories:
    this.categoryService
      .getCategories(),

  bookmarks:
    this.user
      ? this.bookmarkService
          .getBookmarks(
            this.user.id
          )
      : of({
          success: true,
          message: '',
          data: []
        })

})
.subscribe({

  next: (result) =>
  {
    const bookmarkIds =
      (
        result.bookmarks
          .data || []
      ).map(
        (
          bookmark:
          BookmarkResponseModel
        ) => bookmark.articleId
      );

    this.articles =
      (
        result.articles
          .data || []
      ).map(
        (
          article:
          ArticleListModel
        ) => ({
          ...article,

          isBookmarked:
            bookmarkIds.includes(
              article.id
            )
        })
      );

    this.filteredArticles =
      [...this.articles];

    this.categories =
      result.categories
        .data || [];

    this.isLoading = false;
  },

  error: (err: unknown) =>
  {
    console.log(err);

    this.isLoading = false;

    this.notify.error(
      'Failed to load data'
    );
  }
});


  }

  toggleBookmark(articleId: number): void {

    if (!this.user) {
      return;
    }

    if (this.bookmarkLoadingId !== null) {
      return;
    }

    this.bookmarkLoadingId = articleId;

    const article =
      this.articles.find(
        a => a.id === articleId
      );

    if (!article) {

      this.bookmarkLoadingId = null;
      return;
    }

    if (article.isBookmarked) {

      this.bookmarkService
        .removeBookmark(
          this.user.id,
          articleId
        )
        .subscribe({

          next: () => {

            this.updateBookmarkState(
              articleId,
              false
            );

            this.notify.success(
              'Bookmark removed'
            );

            this.bookmarkLoadingId = null;
          },

          error: () => {

            this.notify.error(
              'Failed to remove bookmark'
            );

            this.bookmarkLoadingId = null;
          }

        });

    }

    else {

      this.bookmarkService
        .addBookmark({

          userId: this.user.id,

          articleId: articleId

        })
        .subscribe({

          next: () => {

            this.updateBookmarkState(
              articleId,
              true
            );

            this.notify.success(
              'Bookmark added'
            );

            this.bookmarkLoadingId = null;
          },

          error: () => {

            this.notify.error(
              'Failed to add bookmark'
            );

            this.bookmarkLoadingId = null;
          }

        });

    }

  }



  addBookmark(
    articleId: number
  ): void {

   
if (!this.user)
{
  return;
}

this.bookmarkService
  .addBookmark({

    userId:
      this.user.id,

    articleId:
      articleId
  })
  .subscribe({

    next: () =>
    {
      this.updateBookmarkState(
        articleId,
        true
      );

      this.notify.success(
        'Bookmark added'
      );
    },

    error: (err: unknown) =>
    {
      console.log(err);

      this.notify.error(
        'Failed to add bookmark'
      );
    }
  });


  }

  removeBookmark(
    articleId: number
  ): void {

if (!this.user)
{
  return;
}

this.bookmarkService
  .removeBookmark(
    this.user.id,
    articleId
  )
  .subscribe({

    next: () =>
    {
      this.updateBookmarkState(
        articleId,
        false
      );

      this.notify.success(
        'Bookmark removed'
      );
    },

    error: (err: unknown) =>
    {
      console.log(err);

      this.notify.error(
        'Failed to remove bookmark'
      );
    }
  });


  }

  updateBookmarkState(
    articleId: number,
    value: boolean
  ): void {

   
this.articles =
  this.articles.map(
    article =>
      article.id === articleId
        ? {
            ...article,
            isBookmarked:
              value
          }
        : article
  );

this.filterArticles();


  }

  filterArticles(): void {

  
if (!this.selectedCategory)
{
  this.filteredArticles =
    [...this.articles];

  return;
}

const selectedCategoryName =
  this.categories.find(
    category =>
      category.id ===
      Number(
        this.selectedCategory
      )
  )?.name;

this.filteredArticles =
  this.articles.filter(
    article =>
      article.categoryName ===
      selectedCategoryName
  );


  }

  readArticle(
    id: number
  ): void {

 
this.router.navigate([
  '/articles',
  id
]);

  }
}
