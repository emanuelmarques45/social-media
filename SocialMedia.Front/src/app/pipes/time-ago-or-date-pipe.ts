import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'timeAgoOrDate',
  standalone: false
})
export class TimeAgoOrDatePipe implements PipeTransform {
  transform(value: Date | string): string {
    if (!value) return '';

    const date = new Date(value);
    const now = new Date();
    const diffInMs = now.getTime() - date.getTime();
    const diffInDays = diffInMs / (1000 * 60 * 60 * 24);

    if (diffInDays >= 7) {
      return date.toLocaleDateString('en-US');
    }

    const diffInSeconds = Math.floor(diffInMs / 1000);
    const diffInMinutes = Math.floor(diffInSeconds / 60);
    const diffInHours = Math.floor(diffInMinutes / 60);

    if (diffInSeconds < 60) {
      return `${diffInSeconds} second(s) ago`;
    } else if (diffInMinutes < 60) {
      return `${diffInMinutes} minute(s) ago`;
    } else if (diffInHours < 24) {
      return `${diffInHours} hour(s) ago`;
    } else {
      return `${Math.floor(diffInDays)} day(s) ago`;
    }
  }
}
