import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostLike } from '../../models/like/like.model';

@Injectable({
  providedIn: 'root'
})
export class PostLikeService {
  private apiUrl = 'https://localhost/api/likes';

  constructor(private http: HttpClient) { }

  toggleLike(postId: number, userId: string): Observable<PostLike> {
    return this.http.post<PostLike>(`${this.apiUrl}/post`, { targetId: postId, userId, likeType: 0 });
  }
}
