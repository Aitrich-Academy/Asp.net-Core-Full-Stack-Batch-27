import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobsComponent } from './jobs.component';
import { Job } from '../job';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { NavbarComponent } from '../navbar/navbar.component';

describe('JobsComponent', () => {
  let component: JobsComponent;
  let fixture: ComponentFixture<JobsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ 
        JobsComponent,
        SidebarComponent,
        NavbarComponent
      ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(JobsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should render the template and initialize values', () => {
    expect(fixture.nativeElement.querySelector('.search-container')).toBeTruthy();
    expect(fixture.nativeElement.querySelector('.suggestion-container')).toBeTruthy();
    expect(fixture.nativeElement.querySelector('.card-container')).toBeTruthy();
  
    expect(component.divBackgroundColor1).toBe('rgb(202, 169, 232)');
    // Add similar expectations for other divBackgroundColor properties and other initial values
  });

  it('should change and reset background colors', () => {
    component.changeBackground(1);
    expect(component.divBackgroundColor1).toBe('#ad14d7');
  
    component.resetBackground(1);
    expect(component.divBackgroundColor1).toBe('rgb(202, 169, 232)');
  });

  it('should filter jobs based on jobName', () => {
    // Test filtering with 'All'
    component.filter('All');
    expect(component.tempJobs.length).toBe(component.jobs.length);
  
    // Test filtering with 'programmer'
    component.filter('programmer');
    expect(component.tempJobs.length).toBe(2); // Expected number of filtered jobs
  
    // Test filtering with 'Non-existent Job Name'
    component.filter('Non-existent Job Name');
    expect(component.tempJobs.length).toBe(0); // No jobs should match
  });

  it('should render job data correctly', () => {
    component.tempJobs = [/* Provide sample job data here for testing */];
    fixture.detectChanges();
  
    // Add expectations to verify that the job data is rendered correctly in the template
  });

  it('should display "No jobs found" message when no jobs are found', () => {
    component.tempJobs = [];
    fixture.detectChanges();
  
    const noJobsFoundElement = fixture.nativeElement.querySelector('p');
    expect(noJobsFoundElement).toBeTruthy();
    expect(noJobsFoundElement.textContent).toContain('No jobs found');
  });

  // Import necessary modules and setup

  it('should format location correctly', () => {
    // Create a sample job
    const job: Job = {
      jobTitle: 'Database Programmer',
      companyName: 'Maximoz Team',
      salary: '30,000 - 40,000',
      jobDescription: 'Meeting with the development team to discuss user interface ideas and applications. Reviewing application requirements and interface designs.',
      location: 'Bangalore, India'
    };

    // Call the formattedLocation function
    const formattedLocation = component.formattedLocation(job);

    // Expect the result to match the expected format
    expect(formattedLocation).toEqual('Bangalore, India, Maximoz Team');
  });

  it('should format location correctly with a different job', () => {
    // Create a different sample job
    const job: Job = {
      jobTitle: 'Software Engineer',
      companyName: 'Tech Solutions',
      salary: '40,000 - 50,000',
      jobDescription: 'Working on software development projects.',
      location: 'New York, USA'
    };

    // Call the formattedLocation function
    const formattedLocation = component.formattedLocation(job);

    // Expect the result to match the expected format
    expect(formattedLocation).toEqual('New York, USA, Tech Solutions');
  });

it('should render job data from tempJobs array', () => {2
  const sampleJobs: Job[] = [
    /* Provide sample job data here for testing */
  ];
  component.tempJobs = sampleJobs;
  fixture.detectChanges();

  // Add expectations to verify that the job data from tempJobs is rendered correctly in the template
});

});
