import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';

@Component({
  standalone: true,
  templateUrl: './register.html',
  styleUrl: './login.css',
  imports: [FormsModule, RouterLink]
})
export class Register implements OnInit {

  name = '';
  email = '';
  password = '';
  role = 2;
  msg = '';
  isError = false;

  // CAPTCHA
  captchaA = 0;
  captchaB = 0;
  captchaInput = '';
  captchaError = '';

  private http = inject(HttpClient);
  private router = inject(Router);

  ngOnInit() { this.generateCaptcha(); }

  generateCaptcha() {
    this.captchaA = Math.floor(Math.random() * 9) + 1;
    this.captchaB = Math.floor(Math.random() * 9) + 1;
    this.captchaInput = '';
    this.captchaError = '';
  }

  register() {
    this.msg = '';
    this.captchaError = '';
    this.isError = false;

    if (+this.captchaInput !== this.captchaA + this.captchaB) {
      this.captchaError = '❌ Wrong answer — try again.';
      this.generateCaptcha();
      return;
    }

    this.http.post<any>('https://localhost:7143/api/Auth/register', {
      name: this.name,
      email: this.email,
      password: this.password,
      role: +this.role
    }).subscribe({
      next: (res) => {
        this.msg = res.message || 'Registered successfully!';
        this.isError = false;
        setTimeout(() => this.router.navigate(['/login']), 1500);
      },
      error: (err) => {
        this.msg = err.error?.message || 'Registration failed.';
        this.isError = true;
        this.generateCaptcha();
      }
    });
  }
}