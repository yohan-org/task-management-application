import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class AuthService {
  private readonly storageKey = 'loggedIn';

  login(username: string, password: string): boolean {
    // Replace with API call if needed
    return username === 'admin' && password === 'admin';
  }

  logout(): void {
    localStorage.removeItem(this.storageKey);
  }

  /** Check if user is authenticated */
  isAuthenticated(): boolean {
    return localStorage.getItem(this.storageKey) === 'true';
  }
}
