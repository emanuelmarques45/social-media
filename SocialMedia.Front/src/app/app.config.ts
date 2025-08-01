import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { provideClientHydration } from '@angular/platform-browser';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { provideHttpClient, withFetch, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './interceptors/auth.interceptor';
import { AppModule } from './app.module';

export const appConfig: ApplicationConfig = {
  providers:
    [
      provideRouter(routes),
      provideClientHydration(),
      provideAnimationsAsync(),
      provideHttpClient(withInterceptors([authInterceptor]), withFetch()),
      importProvidersFrom(AppModule)
    ],
};
