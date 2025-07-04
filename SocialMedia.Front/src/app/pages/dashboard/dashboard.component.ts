import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { PostService } from '../../services/post/post.service';
import { User } from '../../models/user/user.model';
import { Post } from '../../models/post/post.model';
import { switchMap, tap } from 'rxjs';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrl: './dashboard.component.css',
  standalone: false
})
export class DashboardComponent {
  user: User = new User();
  posts: Post[] = [];

  constructor(
    private authService: AuthService,
    private postService: PostService
  ) { }

  ngOnInit(): void {
    this.loadUser();
  }

  loadUser(): void {
    this.authService.getCurrentUser().pipe(
      tap(user => this.user = user),
      switchMap(user => this.postService.getUserPosts(user.id))
    ).subscribe(posts => {
      this.posts = posts;
    });
  }

  logout(): void {
    this.authService.logout();
  }
}
