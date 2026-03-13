import { Component } from '@angular/core';
import { Company } from '../jobproviderlist';

@Component({
  selector: 'app-content',
  templateUrl: './content.component.html',
  styleUrls: ['./content.component.css']
})
export class ContentComponent {
  company: Company[];
  filteredCompany :Company[];
  constructor() {
    this.company = [
      {
        companyName: "Funk Inc.",
        jobRole: "IT Department"
      },
      {
        companyName: "Aitrich Ltd.",
        jobRole: "IT Department"

      },
      {
        companyName: "Highspeed Studios",
        jobRole: "Creative Design Agency"
      },
      {
        companyName: "Mosciski Inc.",
        jobRole: "Creative Design Agency"
      },
      {
        companyName: "Incubator Studios",
        jobRole: "Software House"
      },
      {
        companyName: "Naonotu Inc.",
        jobRole: "Creative Design Agency"
      },
      {
        companyName: "ColoColo Studios",
        jobRole: "Internet Service Porvider"
      },
      {
       companyName: "Funk Inc.",
        jobRole: "IT Department"
      },
      {
        companyName: "Mosciski Inc.",
        jobRole: "Creative Design Agency"
      },
      {
        companyName: "Highspeed Studios",
        jobRole: "Creative Design Agency"
      },
      {
        companyName: "Simonis Ltd",
        jobRole: "Internet Service Porvider"
      },
      {
        companyName: "Funk Inc.",
        jobRole: "IT Department"
      },
    ];

    this.filteredCompany = this.company;
  }

  filterJobs(event: Event): void {
    const searchTerm = (event.target as HTMLInputElement).value;
    this.filteredCompany = this.company.filter(company =>
      company.companyName.toLowerCase().includes(searchTerm.toLowerCase()) ||
      company.jobRole.toLowerCase().includes(searchTerm.toLowerCase())
    );
  }

  isHovered: boolean = false;

}



