import { Component, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { JobService } from '../job.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],

})
export class LoginComponent {
  email: string = '';
  password: string = '';
  @ViewChild('loginForm')
  loginForm!: NgForm;
  errorMessage: string = '';
  // email: string = '';
  // password: string = '';
  // loginForm: any;
  
  constructor(private JobService: JobService, private router: Router) { }
  loginSubmit() {
    const isAuthenticated = this.JobService.authenticate(this.email, this.password);
    if (isAuthenticated) {
      console.log('Login successful');
      this.router.navigate(['/JobList']);
    } else { 
      this.errorMessage = 'Wrong username or password. Please try again.';
    }
  }
  clearErrorMessage() {
    this.errorMessage = '';
  }
}

