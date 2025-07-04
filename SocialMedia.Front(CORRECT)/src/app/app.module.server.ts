import { NgModule } from '@angular/core';
import { ServerModule, provideServerRendering } from '@angular/platform-server';

import { AppModule } from './app.module';
import { AppComponent } from './app.component';
import { serverRoutes } from './app.routes.server';
import { provideRouter } from '@angular/router';

@NgModule({
  imports: [
    AppModule,
    ServerModule,
  ],
  bootstrap: [AppComponent],
  providers: [
    //provideRouter(serverRoutes),
    //provideServerRendering()
  ]
})
export class AppServerModule {}
