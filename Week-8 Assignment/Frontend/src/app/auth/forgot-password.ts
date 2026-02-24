import { Component, inject, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Router, RouterLink } from '@angular/router';

@Component({
    standalone: true,
    selector: 'app-forgot-password',
    templateUrl: './forgot-password.html',
    styleUrl: './login.css',
    imports: [FormsModule, RouterLink]
})
export class ForgotPassword implements OnInit {

    // Step 1: email verification
    email = '';
    step = 1;  // 1 = enter email, 2 = reset password
    msg = '';
    isError = false;
    loading = false;

    // Step 2: new password
    newPassword = '';
    confirmPassword = '';

    // CAPTCHA (on step 1)
    captchaA = 0;
    captchaB = 0;
    captchaInput = '';
    captchaError = '';

    private http = inject(HttpClient);
    private router = inject(Router);
    private api = 'https://localhost:7143/api/Auth';

    ngOnInit() { this.generateCaptcha(); }

    generateCaptcha() {
        this.captchaA = Math.floor(Math.random() * 9) + 1;
        this.captchaB = Math.floor(Math.random() * 9) + 1;
        this.captchaInput = '';
        this.captchaError = '';
    }

    verifyEmail() {
        this.msg = '';
        this.isError = false;
        this.captchaError = '';

        if (+this.captchaInput !== this.captchaA + this.captchaB) {
            this.captchaError = '❌ Wrong CAPTCHA answer — try again.';
            this.generateCaptcha();
            return;
        }

        this.loading = true;
        this.http.post<any>(`${this.api}/forgot-password`, { email: this.email })
            .subscribe({
                next: () => {
                    this.loading = false;
                    this.step = 2;
                    this.msg = '';
                },
                error: (err) => {
                    this.loading = false;
                    this.msg = err.error?.message || 'Email not found.';
                    this.isError = true;
                    this.generateCaptcha();
                }
            });
    }

    resetPassword() {
        this.msg = '';
        this.isError = false;

        if (this.newPassword !== this.confirmPassword) {
            this.msg = 'Passwords do not match.';
            this.isError = true;
            return;
        }
        if (this.newPassword.length < 6) {
            this.msg = 'Password must be at least 6 characters.';
            this.isError = true;
            return;
        }

        this.loading = true;
        this.http.post<any>(`${this.api}/reset-password`, {
            email: this.email,
            newPassword: this.newPassword
        }).subscribe({
            next: (res) => {
                this.loading = false;
                this.msg = res.message || 'Password reset! Redirecting to login…';
                this.isError = false;
                setTimeout(() => this.router.navigate(['/login']), 1800);
            },
            error: (err) => {
                this.loading = false;
                this.msg = err.error?.message || 'Reset failed.';
                this.isError = true;
            }
        });
    }
}
