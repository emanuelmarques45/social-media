import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from '../services/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const authService = inject(AuthService);
  const router = inject(Router);

  console.log('AuthGuard activated for route:', state.url);
  console.log('Is user logged in (from AuthService):', authService.isLoggedIn());

  if (authService.isLoggedIn()) {
    console.log('User is logged in, allowing access.');
    return true;
  }

  console.log('User is NOT logged in, redirecting to /login.');

  return router.parseUrl('/login');
};
