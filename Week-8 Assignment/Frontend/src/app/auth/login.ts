import { Component, inject, OnInit, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  standalone: true,
  templateUrl: './login.html',
  styleUrl: './login.css',
  imports: [FormsModule, RouterLink]
})
export class Login implements OnInit {

  email = '';
  password = '';
  error = '';

  // CAPTCHA
  captchaA = 0;
  captchaB = 0;
  captchaInput = '';
  captchaError = '';

  private http = inject(HttpClient);
  private router = inject(Router);
  private authService = inject(AuthService);
  private platformId = inject(PLATFORM_ID);

  ngOnInit() { this.generateCaptcha(); }

  generateCaptcha() {
    this.captchaA = Math.floor(Math.random() * 9) + 1;
    this.captchaB = Math.floor(Math.random() * 9) + 1;
    this.captchaInput = '';
    this.captchaError = '';
  }

  login() {
    this.error = '';
    this.captchaError = '';

    if (+this.captchaInput !== this.captchaA + this.captchaB) {
      this.captchaError = '❌ Wrong answer — try again.';
      this.generateCaptcha();
      return;
    }

    this.http.post<any>('https://localhost:7143/api/Auth/login', {
      email: this.email,
      password: this.password
    }).subscribe({
      next: (res) => {
        if (isPlatformBrowser(this.platformId)) {
          localStorage.setItem('user', JSON.stringify(res));
        }
        if (res.role === 'Admin') this.router.navigate(['/admin']);
        else if (res.role === 'Agent') this.router.navigate(['/agent']);
        else this.router.navigate(['/customer']);
      },
      error: (err) => {
        this.error = err.error?.message || 'Invalid login';
        this.generateCaptcha();
      }
    });
  }
}