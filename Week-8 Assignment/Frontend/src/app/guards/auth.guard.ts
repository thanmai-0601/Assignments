import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route) => {
    const auth = inject(AuthService);
    const router = inject(Router);

    if (!auth.isLoggedIn()) {
        router.navigate(['/login']);
        return false;
    }

    const requiredRole = route.data?.['role'] as string | undefined;
    if (requiredRole && auth.getRole() !== requiredRole) {
        const role = auth.getRole();
        if (role === 'Admin') router.navigate(['/admin']);
        else if (role === 'Agent') router.navigate(['/agent']);
        else router.navigate(['/customer']);
        return false;
    }

    return true;
};
