import { RenderMode, ServerRoute } from '@angular/ssr';
import { FeedComponent } from './pages/feed/feed.component';

export const serverRoutes: ServerRoute[] = [
  {
    path: '**',
    renderMode: RenderMode.Client,
  },
];
