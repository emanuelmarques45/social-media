import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { PostLike } from '../../models/like/like.model';
import { environment } from '@env';

@Injectable({
  providedIn: 'root'
})
export class PostLikeService {
  constructor(private http: HttpClient) { }

  toggleLike(postId: number, userId: string): Observable<PostLike> {
    return this.http.post<PostLike>(`${environment.apiUrl}/likes/post`, { targetId: postId, userId, likeType: 0 });
  }
}
