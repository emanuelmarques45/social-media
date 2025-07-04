// app.routes.server.ts

import { PostComponent } from './pages/post/post.component';

export const serverRoutes: ServerRoute[] = [
  {
    path: 'posts',
    component: PostComponent,
    renderMode: RenderMode.Server,
  },
];
