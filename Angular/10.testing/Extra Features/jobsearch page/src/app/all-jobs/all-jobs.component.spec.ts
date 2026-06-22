import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AllJobsComponent } from './all-jobs.component';
import { ChildComponent } from '../child/child.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';
import { SecondFooterComponent } from '../second-footer/second-footer.component';
import { By } from '@angular/platform-browser';
import { RouterTestingModule } from '@angular/router/testing';

describe('AllJobsComponent', () => {
  let component: AllJobsComponent;
  let fixture: ComponentFixture<AllJobsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AllJobsComponent, ChildComponent],
      imports: [RouterTestingModule],
    });

    fixture = TestBed.createComponent(AllJobsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the AllJobsComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should pass selectedJob to ChildComponent', () => {
    const childComponent = fixture.debugElement.query(By.directive(ChildComponent)).componentInstance;
    expect(childComponent.selectedJob).toEqual(component.selectedJob);
  });

  it('should call showJobDetails and update selectedJob in ChildComponent', () => {
    const childComponent = fixture.debugElement.query(By.directive(ChildComponent)).componentInstance;
    const job = {
      jobId: 1,
      designation: 'UI/UX Designer',
      // Add other properties as needed
    };

    component.showJobDetails(job);
    fixture.detectChanges();

    expect(childComponent.selectedJob).toEqual(job);
  });

  
  it('should bind job data to the template', () => {
    // Select job elements using debugElement
    const jobElements = fixture.debugElement.queryAll(By.css('.job'));

    // Ensure the number of job elements matches the number of jobs in the component
    expect(jobElements.length).toEqual(component.jobs.length);

    // Check the content of individual job elements
    for (let i = 0; i < component.jobs.length; i++) {
      const job = component.jobs[i];
      const jobElement = jobElements[i].nativeElement;

      // Test job designation
      const designation = jobElement.querySelector('.job-header p');
      expect(designation.textContent).toEqual(job.designation);

      // Test company name
      const companyName = jobElement.querySelector('.company span');
      expect(companyName.textContent).toEqual(job.companyName);

      // Test location
      const location = jobElement.querySelector('.company span:last-child');
      expect(location.textContent).toEqual('Location');

      // Test save button
      const saveButton = jobElement.querySelector('.save img');
      expect(saveButton.getAttribute('src')).toEqual(job.save);

      // Test job text
      const jobText = jobElement.querySelector('.job-text p');
      expect(jobText.textContent).toEqual(job.jobtext);

      // Test other job details
      const jobDetails = jobElement.querySelectorAll('.pills p');
      expect(jobDetails.length).toEqual(5); // Ensure there are 5 details
      for (let j = 0; j < jobDetails.length; j++) {
        expect(jobDetails[j].textContent).toEqual(job['text' + (j + 1)]);
      }
    }
  });
});
