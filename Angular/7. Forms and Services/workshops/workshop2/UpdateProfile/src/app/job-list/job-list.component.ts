import { Component } from '@angular/core';
import { JobService } from '../job.service';
@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css'],
 
})
export class JobListComponent {

  jobList: any[] = [];
  
  constructor(public JobService: JobService) {
    this.jobList = this.JobService.getJobList();
  }
}
