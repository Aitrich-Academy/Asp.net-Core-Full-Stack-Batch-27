import { Component } from '@angular/core';
import { Job } from '../jobproviderlist';

@Component({
  selector: 'app-jobproviders',
  templateUrl: './jobproviders.component.html',
  styleUrls: ['./jobproviders.component.css']
})
export class JobprovidersComponent {
  jobs: Job[];
  filteredJobs: Job[];
  constructor(){
    this.jobs =[
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

      this.filteredJobs = this.jobs;
  }
  
  filterJobs(event: Event): void {
    const searchTerm = (event.target as HTMLInputElement).value.toLowerCase();
    this.filteredJobs = this.jobs.filter(job =>
      job.companyName.toLowerCase().includes(searchTerm) ||
      job.jobRole.toLowerCase().includes(searchTerm)
    );
  }
  
  
  isHovered: boolean = false;
}
