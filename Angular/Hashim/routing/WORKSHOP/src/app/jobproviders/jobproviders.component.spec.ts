import { ComponentFixture, TestBed } from '@angular/core/testing';

import { JobprovidersComponent } from './jobproviders.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { NewRegistrationsComponent } from '../new-registrations/new-registrations.component';

describe('JobprovidersComponent', () => {
  let component: JobprovidersComponent;
  let fixture: ComponentFixture<JobprovidersComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [
        JobprovidersComponent,
        SidebarComponent,
        NewRegistrationsComponent
      ]
    });
    fixture = TestBed.createComponent(JobprovidersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  // Test that the component is created successfully:
  it('should create the JobprovidersComponent', () => {
    expect(component).toBeTruthy();
  });

  // Test that the jobs array is initialized correctly:
  it('should initialize the jobs array correctly', () => {
    expect(component.jobs.length).toBe(12);
    expect(component.jobs[0].companyName).toBe('Funk Inc.');
    expect(component.jobs[0].jobRole).toBe('IT Department');
  });

  // Test that the filteredJobs array is initialized correctly:
  it('should initialize the filteredJobs array correctly', () => {
    expect(component.filteredJobs.length).toBe(12);
    expect(component.filteredJobs[0].companyName).toBe('Funk Inc.');
    expect(component.filteredJobs[0].jobRole).toBe('IT Department');
  });

// Test that the filterJobs method filters the jobs array correctly:
it('should filter the jobs array correctly', () => {
  const searchInput = fixture.nativeElement.querySelector('input');
  searchInput.value = 'creative';
  searchInput.dispatchEvent(new Event('input'));
  fixture.detectChanges();
  expect(component.filteredJobs.length).toBe(3);
  expect(component.filteredJobs[0].companyName).toBe('Highspeed Studios');
  expect(component.filteredJobs[0].jobRole).toBe('Creative Design Agency');
});

// Test that the isHovered property is initialized to false:
  it('should initialize the isHovered property to false', () => {
    expect(component.isHovered).toBe(false);
  });

  // Test that the isHovered property is set to true when the mouse enters the search link:
it('should set the isHovered property to true when the mouse enters the search link', () => {
  const searchLink = fixture.nativeElement.querySelector('.search-name');
  searchLink.dispatchEvent(new Event('mouseenter'));
  fixture.detectChanges(); // Trigger change detection after mouseenter
  expect(component.isHovered).toBe(true);
});
 

  // Test that the isHovered property is set to false when the mouse leaves the search link:
it('should set the isHovered property to false when the mouse leaves the search link', () => {
  const searchLink = fixture.nativeElement.querySelector('.search-name');
  searchLink.dispatchEvent(new Event('mouseenter')); // Simulate mouseenter first
  fixture.detectChanges(); // Trigger change detection after mouseenter
  searchLink.dispatchEvent(new Event('mouseleave'));
  fixture.detectChanges(); // Trigger change detection after mouseleave
  expect(component.isHovered).toBe(false);
});
});
