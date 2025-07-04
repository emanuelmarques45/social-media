import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post/post.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PostLikeService } from '../../services/likePost/like.service';
import { PostLike } from '../../models/like/like.model';
import { Post } from '../../models/post/post.model';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css'],
  standalone: false
})
export class PostComponent implements OnInit {
  posts: Post[] = [];
  newPost: Post = new Post();
  postForm!: FormGroup;
  currentUserId: string = "";

  constructor(
    private postService: PostService,
    private postLikeService: PostLikeService,
    private authService: AuthService,
    private fb: FormBuilder) { }

  ngOnInit(): void {
    this.authService.getCurrentUser().subscribe({
      next: (user) => {
        this.currentUserId = user.id;
      }
    });
    this.loadPosts();
    this.postForm = this.fb.group({
      content: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.postForm.valid) {

      this.newPost = { ...this.postForm.value, userId: this.currentUserId }

      this.addPost();

      this.newPost = new Post();

      this.postForm.reset();
    }
  }

  loadPosts(): void {
    this.postService.getPosts().subscribe(data => {
      this.posts = data
      console.log('Posts carregados:', this.posts);
    });
  }

  addPost(): void {
    this.postService.createPost(this.newPost).subscribe(() => {
      this.newPost = new Post();
      this.loadPosts();
    });
  }

  removePost(id: number): void {
    this.postService.deletePost(id).subscribe(() => this.loadPosts());
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
          // Remove o like atual
          this.posts[index].likes = post.likes.filter(like => like.userId !== this.currentUserId);
        } else {
          // Adiciona o novo like
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
}
