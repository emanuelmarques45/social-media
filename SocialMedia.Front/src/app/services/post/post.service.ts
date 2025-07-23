
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { lastValueFrom, Observable } from 'rxjs';
import { Post } from '../../models/post/post.model';
import { environment } from '@env';


@Injectable({ providedIn: 'root' })
export class PostService {
  constructor(private http: HttpClient) { }

  async getPosts(): Promise<Post[]> {
    return await lastValueFrom(this.http.get<Post[]>(`${environment.apiUrl}/posts?SortBy=CreatedAt&IsDescending=true`));
  }

  getPost(id: number): Observable<Post> {
    return this.http.get<Post>(`${environment.apiUrl}/posts/${id}`);
  }

  createPost(post: Post): Observable<Post> {
    return this.http.post<Post>(`${environment.apiUrl}/posts`, post);
  }

  updatePost(post: Post): Observable<void> {
    return this.http.put<void>(`${environment.apiUrl}/posts/${post.id}`, post);
  }

  async deletePost(id: number): Promise<void> {
    return await lastValueFrom(this.http.delete<void>(`${environment.apiUrl}/posts/${id}`));
  }

  getUserPosts(userId: string): Observable<Post[]> {
    return this.http.get<Post[]>(`${environment.apiUrl}/users/${userId}/posts`)
  }
}
