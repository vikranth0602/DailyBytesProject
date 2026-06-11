import { Component } from '@angular/core';

import { CommonModule } from '@angular/common';

import { ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router, ActivatedRoute } from '@angular/router';

import { AuthService } from '../../services/auth';

import { AuthResponseModel } from '../../models/auth/auth-response.model';

import { ApiResponse } from '../../models/shared/api-response.model';

import { AuthApiService } from '../../services/auth-api.service';

import { NotificationService } from '../../services/notification.service';

@Component({
  selector: 'app-sign-ui',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './sign-ui.html',
  styleUrls: ['./sign-ui.css']
})
export class SignUiComponent {

  ngOnInit(): void {

    this.route.queryParams.subscribe(params => {

      this.isLoginMode =
        params['mode'] !== 'register';

    });

  }

  isLoginMode = true;

  loginForm!: FormGroup;

  registerForm!: FormGroup;

  isLoading = false;

  showLoginPassword = false;

  showRegisterPassword = false;

  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private authApi: AuthApiService,
    private notify: NotificationService,
    private router: Router,
    private route: ActivatedRoute
  ) {

    this.loginForm = this.fb.group({

      email: [
        '',
        [
          Validators.required,
          Validators.email
        ]
      ],

      password: [
        '',
        [
          Validators.required,
          Validators.minLength(6)
        ]
      ]
    });

    this.registerForm = this.fb.group({

      firstName: [
        '',
        Validators.required
      ],

      lastName: [
        '',
        Validators.required
      ],

      email: [
        '',
        [
          Validators.required,
          Validators.email
        ]
      ],

      password: [
        '',
        [
          Validators.required,
          Validators.minLength(8),
          Validators.pattern(
            /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).+$/
          )
        ]
      ]
    });
  }

  switchMode(): void {

    const mode =
      this.isLoginMode
        ? 'register'
        : 'login';

    this.router.navigate(
      ['/auth'],
      {
        queryParams: { mode }
      }
    );
  }

  login(): void {

    if (this.loginForm.invalid) {

      this.loginForm.markAllAsTouched();

      return;
    }

    this.isLoading = true;

    this.authApi.login(
      this.loginForm.value
    )
      .subscribe({

        next: (res) => {

          this.auth.login(res.data);

          this.notify.success(res.message);

          this.isLoading = false;

          this.router.navigate([
            '/articles'
          ]);
        },

        error: (err) => {

          this.isLoading = false;

          const message =
            err?.error?.message ||
            'Invalid credentials';

          this.notify.error(message);
        }
      });
  }



  register(): void {

    if (this.registerForm.invalid) {

      this.registerForm.markAllAsTouched();

      return;
    }

    this.router.navigate(
      ['/auth'],
      {
        queryParams: {
          mode: 'login'
        }
      }
    );

    this.authApi.register(
      this.registerForm.value
    )
      .subscribe({

        next: (res) => {

          this.notify.success(res.message);

          this.isLoading = false;

          this.isLoginMode = true;

          this.registerForm.reset();
        },

        error: (err) => {

          this.isLoading = false;

          const message =
            err?.error?.message ||
            'Registration failed';

          this.notify.error(message);
        }
      });
  }

}
