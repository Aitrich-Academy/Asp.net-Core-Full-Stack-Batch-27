import { Component, OnInit } from '@angular/core';
import { JobService } from '../../services/job.service';

@Component({
  selector: 'app-alljobs-list',
  templateUrl: './alljobs-list.component.html',
  styleUrls: ['./alljobs-list.component.css']
})
export class AlljobsListComponent implements OnInit {

  jobs: any[] = [];

  selectedJob: any;

  constructor(private jobService: JobService) { }

  ngOnInit() {
    this.jobService.getJobs().subscribe((jobs: any[]) => {
      this.jobs = jobs;
      console.log(this.jobs);
      this.selectedJob = this.jobs[0];
    })
  }

  viewJobDetail(job: any) {
    this.selectedJob = job;
  }



}
