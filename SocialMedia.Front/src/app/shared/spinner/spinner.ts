import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.html',
  styleUrl: './spinner.css',
  standalone: false
})
export class Spinner {
  @Input() isLoading = false;
}
