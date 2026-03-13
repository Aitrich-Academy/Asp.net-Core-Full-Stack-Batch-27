import { Component } from '@angular/core';
import { Job } from '../job';

@Component({
  selector: 'app-jobs',
  templateUrl: './jobs.component.html',
  styleUrls: ['./jobs.component.css']
})
export class JobsComponent {
  blue: string = "#ad14d7";
  resetBlue: string = "rgb(202, 169, 232)";
  divBackgroundColor1: string = "rgb(202, 169, 232)";
  divBackgroundColor2: string = "rgb(202, 169, 232)";
  divBackgroundColor3: string = "rgb(202, 169, 232)";
  divBackgroundColor4: string = "rgb(202, 169, 232)";
  divBackgroundColor5: string = "rgb(202, 169, 232)";

  

  resetBackground(resetNumber: any) {

    switch (resetNumber) {
      case 1: this.divBackgroundColor1 = this.resetBlue;
        break;
      case 2: this.divBackgroundColor2 = this.resetBlue;
        break;
      case 3: this.divBackgroundColor3 = this.resetBlue;
        break;
      case 4: this.divBackgroundColor4 = this.resetBlue;
        break;
      case 5: this.divBackgroundColor5 = this.resetBlue;
        break;
    }

  }
  jobs: Job[] =
    [{

      jobTitle: "Database Progammer",
      companyName: "Maximoz Team",
      salary: "30000-40000",
      jobDescription: "Meeting with the development team to discuss user interface ideas and applications. Reviewing application requirements and interface designs.",
      location: "Bangalore, India"

    },
    {
      jobTitle: "Intern Programmer",
      companyName: "Colo Colo Studios",
      salary: "14,000 - 25,000",
      jobDescription: " Implementing, validating and rolling out assigned software component, Porting, enhancing and customizing existing module",
      location: "Kochi, India"

    },
    {
      jobTitle: "Front end Programmer",
      companyName: "Madju Djaja Studios",
      salary: "34,000 - 50,000",
      jobDescription: " We always welcome people who are energetic and motivated; always willing to learn on the go. If this best describes you, then Brahmanet is the right place.",
      location: "Kochi, India"
    },
    {
      jobTitle: "photographer",
      companyName: "Aitrich Technologies",
      salary: "34,000 - 50,000",
      jobDescription: "Select and assemble proper equipment, and choose settings and props based on client’s wishes and theme of the photo shoot",
      location: "Thrissur, India"
    },
    {
      jobTitle: "DigitalMarketing",
      companyName: "Aitrich Technologies",
      salary: "34,000 - 50,000",
      jobDescription: "Plan and execute digital marketing campaigns,Monitor and analyze the effectiveness of marketing content",
      location: "Thrissur, India"
    },
    {
      jobTitle: "SoftwareEngineer",
      companyName: "Aitrich Technologies",
      salary: "34,000 - 50,000",
      jobDescription: "Laravel for back-end & API experience is a must,Angular experience is good to have but not a must",
      location: "Thrissur, India"
    },
    ]

    totalJobs:number=this.jobs.length;
  tempJobs: Job[] = this.jobs;
  filter(jobName: string) {
    // let tempJobs:Job[]=this.jobs;
    if (jobName === "All") {
      console.log("all");
      return this.tempJobs = this.jobs;
      console.log(this.tempJobs)
    }
    else {
      console.log(jobName)
      const filteredJobs: Job[] = this.jobs.filter(jobs => Object.values(jobs).some(value => typeof value === 'string' && value.toLowerCase().includes(jobName.toLowerCase())));
      return this.tempJobs = filteredJobs;
    }
  }

}
