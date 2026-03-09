import { BootstrapOptions, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { job } from 'src/job';
@Injectable({
  providedIn: 'root'
})

export class JobService {

  private users: { email: string, password: string, fullname: string, username: string, phone: number }[] = [
    { email: 'mail@mail.com', password: 'password', fullname: 'HimaRose', username: 'Hima', phone: 8765457679 }

  ];
  user: any;

  updateUsername(username: string, fullname: string, email: string, phone: number): void {
    const userIndex = this.users.findIndex(user => user.fullname === fullname);
    if (userIndex !== -1) {
      this.users.splice(1, 1);
      this.users[userIndex].username = username;
      this.users[userIndex].fullname = fullname;
      this.users[userIndex].email = email;
      this.users[userIndex].phone = phone;
      console.log('Username updated successfully');
    } else {
      console.error('User not found');
    }

  }


  updatePassword(username: string, oldPassword: string, newPassword: string, confirmPassword: string): void {

    const userIndex = this.users.findIndex(user => user.username === username && user.password === oldPassword);
    if (userIndex !== -1) {
      this.users[userIndex].password = newPassword;
      console.log('Password updated successfully');
    } else {
      console.error('Invalid user or old password');
    }
  }


  constructor(private router: Router) { }

  authenticate(email: string, password: string): boolean {
    const user = this.users.find(user => user.email === email);
    if (user && user.password === password) {
      return true;
    } else {
      return false;
    }
  }
  public jobList: job[] = [

    {
      companyLogo: "../../assets/images/Rectangle 14.png",
      job_post: "UX/UI Designer",
      company_name: "Shopee ",
      description: "We are looking for a UI/UX Designer to turn our software into easy-to- use products for our clients.",
      location: "Indonasia",
      time_schedule: "Full-time",
      salary_range: "$30,000 - $50,000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14 (1).png",
      job_post: "Product Designer",
      company_name: "Amazon",
      description: "We are looking for a Product Designer to turn our software into easy-to- use products for our clients.",
      location: "Indonesia",
      time_schedule: "Full-time",
      salary_range: "$80,000 - $100,000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14 (2).png",
      job_post: "UX Designer",
      company_name: "Ebay",
      description: "We are looking for a UX Designer to turn our software into easy-to- use products for our clients.",
      location: "San Francisco",
      time_schedule: "Full-time",
      salary_range: "$80,000 - $100,000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14.png",
      job_post: "Software Engineer",
      company_name: "Tech Solutions Inc.",
      description: "We are looking for a Software Engineer to turn our software into easy-to- use products for our clients.",
      location: "San Francisco",
      time_schedule: "Full-time",
      salary_range: "$80,000 - $100,000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14 (1).png",
      job_post: "Marketing Manager",
      company_name: "Global Marketing Agency",
      description: "We are looking for a Marketing Manager to turn our software into easy-to- use products for our clients.",
      location: "New York City",
      time_schedule: "Full-time",
      salary_range: "$70,000 - $9000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14.png",
      job_post: "Customer Service Representative",
      company_name: "ServiceFirst Corporation",
      description: "We are looking for a Customer Service Representative to turn our software into easy-to- use products for our clients.",
      location: "Chicago",
      time_schedule: "Part-time",
      salary_range: "$3000 - $5000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14 (1).png",
      job_post: "Graphic Designer",
      company_name: "Creative Designs Studio",
      description: "We are looking for a Graphic Designer to turn our software into easy-to- use products for our clients.",
      location: "Los Angeles",
      time_schedule: "Full-time",
      salary_range: "$50,000 - $60,000"
    },
    {
      companyLogo: "../../assets/images/Rectangle 14 (2).png",
      job_post: "Sales Associate",
      company_name: "Retail Solutions Ltd.",
      description: "We are looking for a Sales Associate to turn our software into easy-to- use products for our clients.",
      location: "Miami",
      time_schedule: "Part-time",
      salary_range: " $30,000 - $50,000 "
    }
  ];

  getJobList() {
    return this.jobList;
  }

}
