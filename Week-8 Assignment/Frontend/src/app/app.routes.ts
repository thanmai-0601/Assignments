import { Routes } from '@angular/router';
import { Admin } from './admin/admin';
import { Agent } from './agent/agent';
import { Customer } from './customer/customer';
import { Login } from './auth/login';
import { Register } from './auth/register';
import { ForgotPassword } from './auth/forgot-password';
import { Profile } from './profile/profile';
import { authGuard } from './guards/auth.guard';

export const routes: Routes = [
  { path: '', redirectTo: 'login', pathMatch: 'full' },
  { path: 'login', component: Login },
  { path: 'register', component: Register },
  { path: 'forgot-password', component: ForgotPassword },
  {
    path: 'admin',
    component: Admin,
    canActivate: [authGuard],
    data: { role: 'Admin' }
  },
  {
    path: 'agent',
    component: Agent,
    canActivate: [authGuard],
    data: { role: 'Agent' }
  },
  {
    path: 'customer',
    component: Customer,
    canActivate: [authGuard],
    data: { role: 'Customer' }
  },
  {
    path: 'profile',
    component: Profile,
    canActivate: [authGuard]
  },
  { path: '**', redirectTo: 'login' }
];

