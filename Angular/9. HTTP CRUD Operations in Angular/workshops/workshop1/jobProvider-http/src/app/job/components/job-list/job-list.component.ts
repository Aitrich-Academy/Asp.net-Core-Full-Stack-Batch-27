import { Component, OnInit } from '@angular/core';
import { JobService } from '../../sevices/job.service';
import { Job } from '../../models/job';

@Component({
  selector: 'app-job-list',
  templateUrl: './job-list.component.html',
  styleUrls: ['./job-list.component.css']
})


export class JobListComponent implements OnInit {
  jobs: Job[] = [];
  activePage: number = 0;
  title = "pagnation";
  POSTS: any;
  page: number = 1;
  count: number = 0;
  tableSize: number = 2;
  tableSizes: any = [5, 10, 15, 20];
  constructor(private jobService: JobService) { }
  ngOnInit() {
    this.postList();


  }
  postList() {
    this.jobService.getJob().subscribe((jobs: Job[]) => {

      this.jobs = jobs;
      this.POSTS = jobs;
      console.log(this.jobs);

    });
  }
  onTableDataChange(event: any) {
    this.page = event;
    this.postList();
  }
  tableSizeChange(event: any) {
    this.tableSize = event.target.value;
    this.page = 1;
    this.postList();
  }

}
