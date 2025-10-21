import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post/post.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostLikeService } from '../../services/likePost/like.service';
import { PostLike } from '../../models/like/like.model';
import { Post } from '../../models/post/post.model';
import { AuthService } from '../../services/auth/auth.service';
import { lastValueFrom } from 'rxjs';
import { ConfirmDialogComponent } from '../../components/dialog/confirm-dialog.component';
import { MatDialog } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { PostComment } from '../../models/comment/comment.model';
import { environment } from '@env';
import { CommentsDialogComponent } from '../../components/comments-dialog/comments-dialog.component';

@Component({
  selector: 'app-feed',
  templateUrl: './feed.component.html',
  styleUrls: ['./feed.component.css'],
  standalone: false
})
export class FeedComponent implements OnInit {
  posts: Post[] = [];
  newPost: Post = new Post();
  postForm!: FormGroup;
  currentUserId: string = "";
  commentForms: { [postId: string]: FormGroup } = {};

  constructor(
    private postService: PostService,
    private postLikeService: PostLikeService,
    private authService: AuthService,
    private dialog: MatDialog,
    private http: HttpClient,
    private fb: FormBuilder) { }

  async ngOnInit(): Promise<void> {
    this.postForm = this.fb.group({
      content: ['', Validators.required]
    });
    this.currentUserId = (this.authService.getCurrentUserValue()).id;
    this.loadPosts();
  }

  onSubmit(): void {
    if (this.postForm.valid) {

      this.newPost = { ...this.postForm.value, userId: this.currentUserId }

      this.addPost();

      this.newPost = new Post();

      this.postForm.reset();
    }
  }

  initializeCommentForms() {
    this.posts.forEach(post => {
      this.commentForms[post.id] = this.fb.group({
        content: ['', Validators.required]
      });
    });
  }

  async loadPosts(): Promise<void> {
    var data = await this.postService.getPosts();
    this.posts = data;
    this.initializeCommentForms()
  }

  addPost(): void {
    this.postService.createPost(this.newPost).subscribe(() => {
      this.newPost = new Post();
      this.loadPosts();
    });
  }

  async removePost(id: number): Promise<void> {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      width: '300px',
      data: {
        title: 'Confirm Delete',
        message: 'Are you sure you want to delete this post?'
      }
    });

    dialogRef.afterClosed().subscribe(async result => {
      if (result === true) {
        await this.postService.deletePost(id)
        await this.loadPosts();
      }
    });
  }

  isLiked(post: Post): boolean {
    return post.likes.some(like => like.userId === this.currentUserId);
  }

  likePost(post: Post) {
    this.postLikeService.toggleLike(post.id, this.currentUserId).subscribe((updatedLike: PostLike) => {
      const index = this.posts.findIndex(p => p.id === post.id);

      if (index > -1) {
        const alreadyLiked = this.isLiked(post);

        if (alreadyLiked) {
          this.posts[index].likes = post.likes.filter(like => like.userId !== this.currentUserId);
        } else {
          this.posts[index].likes.push({
            id: updatedLike.id,
            userId: this.currentUserId,
            postId: post.id,
            createdAt: new Date()
          });
        }
      }
    });
  }

  async getComments(post: Post): Promise<void> {
    post.comments = await lastValueFrom(this.http.get<PostComment[]>(`${environment.apiUrl}/posts/${post.id}/comments`));
    this.dialog.open(CommentsDialogComponent, {
      width: '500px',
      data: { post },
    });
  }
}
