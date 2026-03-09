import { Component } from '@angular/core';
import { AuthService } from '../../services/auth.service';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registeration',
  templateUrl: './registeration.component.html',
  styleUrls: ['./registeration.component.css']
})
export class RegisterationComponent {

  constructor(private authService: AuthService,private router:Router) { }

  signUp(signUpForm:NgForm){
    console.log(signUpForm.value);
    this.authService.signUp(signUpForm.value).subscribe(
      ()=>{this.router.navigate(['login'])}
    )
  }
}
