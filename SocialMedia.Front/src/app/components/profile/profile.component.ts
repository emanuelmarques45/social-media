import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/user/user.model';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { lastValueFrom } from 'rxjs';
import { environment } from '@env';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrl: './profile.component.css',
  standalone: false
})
export class ProfileComponent {
  profileForm!: FormGroup;
  selectedFile?: File;
  profilePictureUrl?: string;
  user!: User;

  constructor(private fb: FormBuilder, private http: HttpClient, private authService: AuthService) {
    this.profileForm = this.fb.group({
      userName: ["", Validators.required],
      email: [{ value: "", disabled: true }],
    });
  }

  async ngOnInit(): Promise<void> {
    this.user = this.authService.getCurrentUserValue();
    this.profileForm.patchValue({
      userName: this.user.userName,
      email: this.user.email,
    });

    this.profileForm.updateValueAndValidity();
    this.loadProfilePicture();
  }

  onFileSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length > 0) {
      this.selectedFile = input.files[0];
    }
  }

  async uploadProfilePicture(): Promise<void> {
    if (!this.selectedFile) return;
    const formData = new FormData();
    formData.append('file', this.selectedFile);

    await lastValueFrom(this.http.post(`${environment.apiUrl}users/upload-profile-picture`, formData));
    const blob = await lastValueFrom(this.http.get(`${environment.apiUrl}users/${this.user.id}/profile-picture`, {
      responseType: 'blob'
    }))

    this.blobToBase64(blob).then(base64 => {
      this.user.profilePicture = base64;
      this.loadProfilePicture(); 
    });
  }

  private blobToBase64(blob: Blob): Promise<string> {
    return new Promise((resolve, reject) => {
      const reader = new FileReader();
      reader.onloadend = () => {
        const result = reader.result as string;
        const base64 = result.split(',')[1]; // Remove the "data:image/png;base64," prefix
        resolve(base64);
      };
      reader.onerror = reject;
      reader.readAsDataURL(blob);
    });
  }

  loadProfilePicture(): void {
    console.log(this.user.profilePicture)
    this.profilePictureUrl = `data: ${this.user.profilePictureContentType}; base64, ${this.user.profilePicture}`;
  }

  async updateUser(): Promise<void> {
    if (this.profileForm.invalid) return;

    const updatedUser: User = { ...this.user, ...this.profileForm.value };
    const updateObject = {
      userName: updatedUser.userName,
      name: this.user.name,
      email: this.user.email
    }

    await lastValueFrom(this.http.put(`${environment.apiUrl}users/${this.user.id}`, updateObject));
    alert('Profile updated!');
    this.authService.setCurrentUser(updatedUser);
  }
}
