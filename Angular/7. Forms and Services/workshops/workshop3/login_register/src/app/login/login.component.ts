import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import { NgForm } from '@angular/forms';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  @ViewChild('loginForm') loginForm!: NgForm;
  constructor(private userService: UserService, private router: Router) { }

  login() {
    // Get form values
    const email = this.loginForm.value.email;
    const password = this.loginForm.value.password;

    // Check if user is registered
    if (this.userService.authenticate(email, password)) {
      // Redirect to dashboard or home page
      this.router.navigate(['/jobs']);
    } else {
      // Show error message
      alert('Invalid credentials');
    }
  }
}
