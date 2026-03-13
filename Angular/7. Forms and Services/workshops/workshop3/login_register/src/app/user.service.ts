import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private registeredUsers: any[] = [];

  register(user: any) {
    // Save user in registeredUsers array or store it in localStorage
    this.registeredUsers.push(user);
  }

  authenticate(email: string, password: string): boolean {
    // Check if user exists in registeredUsers array or in localStorage
    return this.registeredUsers.some(user => user.email === email && user.password === password);
  }
}
