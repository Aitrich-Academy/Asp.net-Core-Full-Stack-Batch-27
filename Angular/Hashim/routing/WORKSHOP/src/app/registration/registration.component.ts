import { Component } from '@angular/core';
import { NewRegistrations } from '../newRegistrations';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent 
{
  newRegistrations: NewRegistrations[];

  filterRegistration : NewRegistrations[];

  constructor(){

    this.newRegistrations =[
      {
        id : "APL0003",
        dateApplied : "2024-06-01",
        company : "Tech Solutions Inc.",
        type : "Full-time",
        position : "Software Engineer",
        contact : "",
        status : "Pending"
      },
      {
        id : "APL0004",
        dateApplied : "2024-06-02",
        company : "Innovatech Ltd.",
        type : "Internship",
        position : "Data Analyst Intern",
        contact : "",
        status : "Candidate"
      },
      {
        id : "APL0005",
        dateApplied : "2024-06-03",
        company : "Global Tech Corp.",
        type : "Part-time",
        position : "UI/UX Designer",
        contact : "",
        status : "On-Hold"
      },
      {
        id : "APL0006",
        dateApplied : "2024-06-04",
        company : "NextGen Software",
        type : "Full-time",
        position : "DevOps Engineer",
        contact : "",
        status : "Pending"
      }
    ];
    this.filterRegistration = this.newRegistrations
  }



 setFilter(status: string) {

  if (status === 'All') {
    this.filterRegistration = this.newRegistrations;
  } else {
    this.filterRegistration = this.newRegistrations.filter(reg =>
      reg.status.toLowerCase() === status.toLowerCase()
    );
  }

}






}
