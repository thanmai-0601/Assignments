import { Injectable, inject, PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { Router } from '@angular/router';

export interface AuthUser {
  id: number;
  name: string;
  email: string;
  role: 'Admin' | 'Agent' | 'Customer';
}

@Injectable({ providedIn: 'root' })
export class AuthService {
  private router = inject(Router);
  private platformId = inject(PLATFORM_ID);

  private get isBrowser(): boolean {
    return isPlatformBrowser(this.platformId);
  }

  getUser(): AuthUser | null {
    if (!this.isBrowser) return null;
    const data = localStorage.getItem('user');
    if (!data) return null;
    try {
      return JSON.parse(data) as AuthUser;
    } catch {
      return null;
    }
  }

  setUser(user: AuthUser): void {
    if (!this.isBrowser) return;
    localStorage.setItem('user', JSON.stringify(user));
  }

  getRole(): string | null {
    return this.getUser()?.role ?? null;
  }

  isLoggedIn(): boolean {
    return !!this.getUser();
  }

  logout(): void {
    if (this.isBrowser) localStorage.removeItem('user');
    this.router.navigate(['/login']);
  }
}
