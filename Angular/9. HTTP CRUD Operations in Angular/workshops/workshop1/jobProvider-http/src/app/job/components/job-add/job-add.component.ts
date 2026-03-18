import { Component } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { JobService } from '../../sevices/job.service';
import { Job } from '../../models/job';

@Component({
  selector: 'app-job-add',
  templateUrl: './job-add.component.html',
  styleUrls: ['./job-add.component.css']
})
export class JobAddComponent {
  addJobForm!: FormGroup;

  constructor(private formBuilder: FormBuilder, private jobService: JobService) { }
  job: Job[] = [];

  ngOnInit() {
    // Form initialization
    this.addJobForm = this.formBuilder.group({
      // Define form controls with validation rules
      jobTitle: ['', Validators.required],
      companyName: ['', Validators.required],
      location: ['', Validators.required],
      jobDescription: ['', Validators.required],
      jobType: ['', [Validators.required]],
      salary: ['', [Validators.required,]],
      onsite: ['', [Validators.required,]]
      // Add more form controls as needed
    });
  }

  onSubmit() {
    //console.log("hai");
    console.log(this.addJobForm.value);
    this.job = this.addJobForm.value;
    this.jobService.addJob(this.job).subscribe(data => {
      console.log(data);
    })

    this.resetForm();

  }
  resetForm() {
    this.addJobForm.reset();
  }

}
