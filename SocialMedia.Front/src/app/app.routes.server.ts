import { RenderMode, ServerRoute } from '@angular/ssr';
import { PostComponent } from './pages/post/post.component';

export const serverRoutes: ServerRoute[] = [
  {
    path: '**',
    renderMode: RenderMode.Client,
  },
];
