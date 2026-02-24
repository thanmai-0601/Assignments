import { Component, inject } from '@angular/core';
import { RouterLink } from '@angular/router';
import { AuthService } from '../services/auth.service';

@Component({
  standalone: true,
  selector: 'app-sidebar',
  templateUrl: './sidebar.html',
  styleUrl: './sidebar.css',
  imports: [RouterLink]
})
export class Sidebar {
  private auth = inject(AuthService);

  get role(): string | null {
    return this.auth.getRole();
  }

  get userName(): string {
    return this.auth.getUser()?.name ?? 'User';
  }

  logout() {
    this.auth.logout();
  }
}