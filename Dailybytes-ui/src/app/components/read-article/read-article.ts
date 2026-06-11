import { Component, OnInit } from '@angular/core';

import { CommonModule } from '@angular/common';

import { FormsModule } from '@angular/forms';

import { ActivatedRoute, Router } from '@angular/router';

import { ArticleService } from '../../services/article.service';

import { CommentService } from '../../services/comment.service';

import { RatingService } from '../../services/rating.service';

import { NotificationService } from '../../services/notification.service';

import { AuthService } from '../../services/auth';

import { UserModel } from '../../models/user/user.model';

import { CommentModel } from '../../models/comment/comment.model';

import { ArticleDetailModel } from '../../models/article/article-detail.model';

import { ApiResponse } from '../../models/shared/api-response.model';

@Component({
  selector: 'app-read-article',
  standalone: true,
  imports: [ CommonModule, FormsModule ],
  templateUrl: './read-article.html',

  styleUrls: [ './read-article.css' ]
})

export class ReadArticleComponent
  implements OnInit {

  article: ArticleDetailModel | null = null;

  comments: CommentModel[] = [];

  user!: UserModel;

  averageRating = 0;

  selectedRating = 0;

  hoverRating = 0;

  userRating = 0;

  commentText = '';

  maxCommentLength = 300;

  minCommentLength = 3;

  readingTime = 1;

  isLoading = false;

  hasRated = false;

  isSubmittingComment = false;

  isSubmittingRating = false;

  currentUser: any;

  constructor(

    private route: ActivatedRoute,

    private articleService: ArticleService,

    private commentService: CommentService,

    private ratingService: RatingService,

    private notify: NotificationService,

    private auth: AuthService,

    private router: Router

  ) { }

  ngOnInit(): void {

    this.currentUser = JSON.parse(localStorage.getItem('user') || 'null');


    const user = this.auth.getCurrentUser();

    if (!user)
    {
      this.notify.error('User not found');
      return;
    }

    this.user = user;

    this.route.paramMap.subscribe({

      next: params =>
      {
        const id = Number( params.get('id') );
        if (!id)
        {
          this.notify.error( 'Invalid article' );
          return;
        }
        this.initializePage(id);
      }

    });

  }

  initializePage(articleId: number): void
  {

    this.isLoading = true;

    this.article = null;

    this.comments = [];

    this.averageRating = 0;

    this.loadArticle(articleId);

    this.loadComments(articleId);

    this.loadAverageRating(articleId);

  }

  loadArticle(id: number): void
  {


    this.articleService
      .getArticleById(id)
      .subscribe({

        next: ( res: ApiResponse<ArticleDetailModel> ) =>
        {
          this.article = res.data;

          const words =
            this.article.content.split(/\s+/).length;

          this.readingTime =
            Math.max(1, Math.ceil(words / 200));

          this.isLoading = false;

        },

        error: () =>
        {
          this.isLoading = false;

          this.notify.error(
            'Failed to load article'
          );
        }
      });


  }

  loadComments(articleId: number): void
  {
    this.commentService
      .getComments(articleId)
      .subscribe({

        next: ( res: ApiResponse<CommentModel[]> ) =>
        {
          this.comments =
            res.data || [];
        },

        error: (
          err: unknown
        ) =>
        {
          console.log(err);
        }

      });
  }

  loadAverageRating(articleId: number): void
  {

    this.ratingService
      .getAverageRating(articleId)
      .subscribe({

        next: ( res: ApiResponse<number> ) =>
        {
          this.averageRating = Number(res.data);
        },

        error: ( err: unknown ) =>
        {
          console.log(err);
        }

      });

  }


  submitRating(star: number): void {

    if (this.isSubmittingRating) {
      return;
    }

    this.selectedRating = star;

    const user = JSON.parse(
      localStorage.getItem('user') || 'null'
    );

    if (!user) {

      this.notify.error( 'Please login to rate articles' );
      return;
    }

    if (!this.article) {

      this.notify.error( 'Article not found' );
      return;
    }

    this.isSubmittingRating = true;

    const request = {

      articleId: this.article.id,

      ratingValue: this.selectedRating
    };

    this.ratingService
      .submitRating(request)
      .subscribe({

        next: (response: any) => {

          this.hasRated = true;

          this.notify.success(
            response.message
          );

          this.loadAverageRating(
            this.article!.id
          );

          this.isSubmittingRating = false;
        },

        error: (err: any) => {

          console.error(err);

          this.notify.error(
            'Rating submission failed'
          );

          this.isSubmittingRating = false;
        }

      });
  }



addComment(): void {

  if (this.isSubmittingComment) {
    return;
  }

  const trimmedComment =
    this.commentText.trim();

  if (!trimmedComment) {

    this.notify.error(
      'Comment cannot be empty'
    );

    return;
  }

  if (
    trimmedComment.length <
    this.minCommentLength
  ) {

    this.notify.error(
      'Comment must be at least 3 characters'
    );

    return;
  }

  if (
    trimmedComment.length >
    this.maxCommentLength
  ) {

    this.notify.error(
      'Comment cannot exceed 500 characters'
    );

    return;
  }

  if (!this.article) {
    return;
  }

  this.isSubmittingComment = true;

  const data = {

    userId: this.user.id,

    articleId: this.article.id,

    message: trimmedComment
  };

  this.commentService
    .addComment(data)
    .subscribe({

      next: () => {

        this.commentText = '';

        this.loadComments(
          this.article!.id
        );

        this.notify.success(
          'Comment added'
        );

        this.isSubmittingComment = false;
      },

      error: (err: unknown) => {

        console.log(err);

        this.notify.error(
          'Failed to add comment'
        );

        this.isSubmittingComment = false;
      }
    });
}







  deleteComment(id: number): void
  {

    this.commentService
      .deleteComment(id)
      .subscribe({

        next: () =>
        {
          this.comments = this.comments.filter( c => c.id !== id );
        },

        error: ( err: unknown ) =>
        {
          console.log(err);
        }
      });

  }

  goBack(): void {
    this.router.navigate([ '/articles' ]);
  }
}
