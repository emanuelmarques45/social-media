import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { provideHttpClient, withInterceptors } from '@angular/common/http';

import { MatInputModule } from '@angular/material/input';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatListModule } from '@angular/material/list';

import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { LoginComponent } from './pages/login/login.component';
import { authInterceptor } from './interceptors/auth.interceptor';
import { FeedComponent } from './pages/feed/feed.component';
import { RouterLink, RouterLinkActive, RouterOutlet } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';
import { TimeAgoOrDatePipe } from './pipes/time-ago-or-date-pipe';
import { ConfirmDialogComponent } from './components/dialog/confirm-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { CommonModule } from '@angular/common';
import { ProfileComponent } from './components/profile/profile.component';
import { Spinner } from './shared/spinner/spinner';
import { CommentsDialogComponent } from './components/comments-dialog/comments-dialog.component';

@NgModule({
  declarations: [
    LoginComponent,
    FeedComponent,
    ProfileComponent,
    LayoutComponent,
    TimeAgoOrDatePipe,
    ConfirmDialogComponent,
    CommentsDialogComponent,
    Spinner
  ],
  imports: [
    BrowserModule,
    FormsModule,
    RouterOutlet,
    RouterLink,
    RouterLinkActive,
    CommonModule,

    MatProgressSpinnerModule,
    MatInputModule,
    MatButtonModule,
    MatCardModule,
    MatIconModule,
    MatFormFieldModule,
    MatToolbarModule,
    ReactiveFormsModule,
    MatSidenavModule,
    MatListModule,
    MatDialogModule
  ],
  providers: [
    provideAnimationsAsync(),
    provideHttpClient(
      withInterceptors([authInterceptor])
    ),
    provideClientHydration()
  ],
})
export class AppModule { }
