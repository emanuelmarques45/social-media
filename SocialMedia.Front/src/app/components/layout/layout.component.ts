import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { User } from '../../models/user/user.model';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css'],
  standalone: false
})
export class LayoutComponent {
  user: User = new User();

  constructor(private authService: AuthService) { }

  async ngOnInit(): Promise<void> {
    this.user = await this.authService.getCurrentUserValue();
    this.authService.setCurrentUser(this.user);
  }

  logout(): void {
    this.authService.logout();
  }
}
