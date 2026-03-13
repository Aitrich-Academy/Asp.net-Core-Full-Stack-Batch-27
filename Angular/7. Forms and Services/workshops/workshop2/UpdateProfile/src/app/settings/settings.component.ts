import { Component,OnInit } from '@angular/core';
import { FormBuilder,FormGroup,Validators } from '@angular/forms';
import { JobService } from '../job.service';
@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css']
})
export class SettingsComponent implements OnInit {
  usernameForm!: FormGroup;
  passwordForm!: FormGroup;
  email: string=''
  fullname:string=''
  username:string=''
  passord:string=''
  oldPassword:string=''
  confirmPassword:string=''
  newPassword:string='';
    constructor(
    private formBuilder: FormBuilder,
    private  jobService: JobService,
  
  ) {}

  ngOnInit() {
    this.usernameForm = this.formBuilder.group({
      fullname: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      phone: ['', Validators.required]
    });

    this.passwordForm = this.formBuilder.group({
      username: ['', Validators.required],
      oldPassword: ['', Validators.required],
      newPassword: ['', Validators.required],
      confirmPassword: ['', Validators.required]
    });
  }

  changeUsername() {
    if (this.usernameForm.valid) {
      const username = this.usernameForm.value.username;
      const fullName = this.usernameForm.value.fullname;
      const email = this.usernameForm.value.email;
      const phone = this.usernameForm.value.phone;

      // Update the user's username in the array
      this.jobService.updateUsername(username, fullName, email, phone);
      console.log('Username updated successfully');
      this.usernameForm.reset();
    }
  }

  changePassword() {
    if (this.passwordForm.valid) {
      const username = this.passwordForm.value.username;
      const oldPassword = this.passwordForm.value.oldPassword;
      const newPassword = this.passwordForm.value.newPassword;
      const confirmPassword = this.passwordForm.value.confirmPassword;

      if (newPassword === confirmPassword) {
        // Update the user's password in the array
        this.jobService.updatePassword(username, oldPassword, newPassword,confirmPassword);
        this.passwordForm.reset();
      } else {
        console.error('New password and confirm password do not match');
      }
    }
  }
}


