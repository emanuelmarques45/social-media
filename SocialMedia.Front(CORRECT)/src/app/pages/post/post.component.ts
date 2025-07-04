import { Component, OnInit } from '@angular/core';
import { PostService } from '../../services/post/post.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Post } from '../../models/post.model';
import { PostLikeService } from '../../services/likePost/like.service';
import { PostLike } from '../../models/like.model';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {
  posts: Post[] = [];
  newPost: Post = new Post();
  postForm!: FormGroup;
  currentUserId: string = "e1186fd1-a53e-45e8-8ba4-bb94bbc5aae3";

  constructor(private postService: PostService, private postLikeService: PostLikeService, private fb: FormBuilder) { }

  ngOnInit(): void {
    this.loadPosts();
    this.postForm = this.fb.group({
      content: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.postForm.valid) {

      this.newPost = { ...this.postForm.value, userId: "e1186fd1-a53e-45e8-8ba4-bb94bbc5aae3" }

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
