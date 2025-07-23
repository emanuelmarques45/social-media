import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { authGuard } from './guards/auth.guard';

import { FeedComponent } from './pages/feed/feed.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ProfileComponent } from './components/profile/profile.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  {
    path: '',
    component: LayoutComponent,
    canActivate: [authGuard],
    children: [
      { path: '', redirectTo: 'feed', pathMatch: 'full' },
      { path: 'feed', component: FeedComponent },
      { path: 'profile', component: ProfileComponent },
    ]
  }
];
