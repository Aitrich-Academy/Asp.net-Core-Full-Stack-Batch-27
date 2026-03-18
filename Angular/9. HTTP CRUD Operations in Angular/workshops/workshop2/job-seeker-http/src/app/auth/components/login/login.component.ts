import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';
import { UserLogin } from '../../models/UserLogin';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  backgroundImageUrl = '../../../../../assets/images/LoginPageImg.png';

  users: any[] = [];

  constructor(
    private authService: AuthService, 
    private router: Router
    ) {



    this.authService.getAllUsers().subscribe(
      (users: any[]) => {
        console.log(users);
        this.users = users;
      }
    )
  }

  login(loginForm: NgForm) {
    console.log(loginForm.value);
    this.users.filter((user: any) => {
      if (loginForm.value.username == user.email && loginForm.value.password == user.password) {
        sessionStorage.setItem('user', JSON.stringify(user))
        this.router.navigate(['jobseeker-home/findAllJobs'])
      }
    })
  }



}
