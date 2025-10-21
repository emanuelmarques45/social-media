import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { environment } from '../../../environments/environment';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Post } from '../../models/post/post.model';
import { HttpClient } from '@angular/common/http';
import { PostComment } from '../../models/comment/comment.model';
import { AuthService } from '../../services/auth/auth.service';
import { lastValueFrom } from 'rxjs';

@Component({
  selector: 'app-comments-dialog',
  templateUrl: './comments-dialog.component.html',
  standalone: false
})
export class CommentsDialogComponent {
  commentForms: { [postId: string]: FormGroup } = {};

  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    private http: HttpClient,
    private fb: FormBuilder,
    private authService: AuthService) { }

  async ngOnInit(): Promise<void> {
    this.initializeCommentForms()
  }

  initializeCommentForms() {
    this.commentForms[this.data.post.id] = this.fb.group({
      content: ['', Validators.required]
    });
  }

  async addComment(post: Post) {
    const form = this.commentForms[post.id];
    if (form.invalid) return;

    const commentData: PostComment = {
      id: 0,
      content: form.value.content,
      postId: post.id,
      userId: post.user.id,
      user: this.authService.getCurrentUserValue()
    };

    const comment: PostComment = await lastValueFrom(
      this.http.post<PostComment>(`${environment.apiUrl}/comments`, commentData)
    );

    form.reset();

    commentData.id = comment.id;

    post.comments.push(commentData);
  }

  async deleteComment(commentId: number) {
    await lastValueFrom(this.http.delete(`${environment.apiUrl}/comments/${commentId}`))
    this.data.post.comments = this.data.post.comments.filter(
      (i: PostComment) => i.id !== commentId
    );
  }

  showDeleteCommentButton(userId: string) {
    return userId == this.authService.getCurrentUserValue().id
  }
}
