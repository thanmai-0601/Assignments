import { Component, inject } from '@angular/core';
import { Sidebar } from '../layout/sidebar';
import { AuthService, AuthUser } from '../services/auth.service';

@Component({
    standalone: true,
    selector: 'app-profile',
    templateUrl: './profile.html',
    styleUrl: './profile.css',
    imports: [Sidebar]
})
export class Profile {
    private auth = inject(AuthService);
    user: AuthUser | null = null;

    ngOnInit() {
        this.user = this.auth.getUser();
    }
}
