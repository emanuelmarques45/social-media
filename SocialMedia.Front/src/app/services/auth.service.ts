import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, lastValueFrom, Observable, tap } from 'rxjs';
import { Router } from '@angular/router';
import { User } from '../models/user/user.model';
import { jwtDecode } from 'jwt-decode';
import { environment } from '@env';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  private currentUserSubject = new BehaviorSubject<User | null>(null);

  constructor(private http: HttpClient, private router: Router) {}

  login(credentials: { email: string; password: string }) {
    return this.http
      .post<{ token: string }>(`${environment.apiUrl}/auth/login`, credentials)
      .pipe(tap((res) => localStorage.setItem('token', res.token)));
  }

  logout(): void {
    localStorage.removeItem('token');
    this.router.navigate(['/login']);
  } 

  isLoggedIn(): boolean {
    const token = this.getToken();
    if (!token) return false;

    try {
      const decoded: { exp: number } = jwtDecode(token);
      const now = Math.floor(Date.now() / 1000);

      return decoded.exp > now;
    } catch (error) {
      console.error('Invalid token', error);
      return false;
    }
  }

  getToken(): string | null {
    return localStorage.getItem('token');
  }

  async getCurrentUser(): Promise<User> {
    return await lastValueFrom(this.http.get<User>(`${environment.apiUrl}/auth/me`));
  }

  setCurrentUser(user: User): void {
    this.currentUserSubject.next(user);
  }

  getCurrentUserValue(): User {
    return this.currentUserSubject.value ?? new User();
  }
}
