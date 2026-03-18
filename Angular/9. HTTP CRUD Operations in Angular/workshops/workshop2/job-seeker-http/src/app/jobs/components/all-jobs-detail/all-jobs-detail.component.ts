import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-all-jobs-detail',
  templateUrl: './all-jobs-detail.component.html',
  styleUrls: ['./all-jobs-detail.component.css']
})
export class AllJobsDetailComponent {
  @Input() job: any;
}
