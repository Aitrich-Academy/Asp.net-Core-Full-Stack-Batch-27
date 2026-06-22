import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChildComponent } from './child.component';
import { By } from '@angular/platform-browser';

describe('ChildComponent', () => {
  let component: ChildComponent;
  let fixture: ComponentFixture<ChildComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ChildComponent],
    });

    fixture = TestBed.createComponent(ChildComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the ChildComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should receive selectedJob as an input', () => {
    const selectedJob = {
      jobId: 1,
      designation: 'UI/UX Designer',
      // Add other properties as needed
    };

    component.selectedJob = selectedJob;
    fixture.detectChanges();

    expect(component.selectedJob).toEqual(selectedJob);
  });

  it('should change the activeTab when changeTab is called', () => {
    const tab = 'jobDesc';
    component.changeTab(tab);

    expect(component.activeTab).toEqual(tab);
  });

  
  it('should bind selectedJob data to the template', () => {
    const selectedJob = {
      companyImg: 'assets/images/company.jpg',
      companyLogo: 'assets/images/logo.png',
      designation: 'UI/UX Designer',
      save: 'assets/images/save-button.png',
      companyName: 'Shopee',
      text1: 'Full-time',
      text2: 'Mid Level',
      text3: '$3000-$5000',
      text4: 'Indonesia',
      text5: 'Onsite',
      companyContent: 'Company description goes here',
      jobDesc: 'Job Description content goes here',
      responsibilities: 'Job responsibilities goes here',
    };
  
    component.selectedJob = selectedJob;
    fixture.detectChanges();
  
    // Test data binding in the template
    const mainImage = fixture.debugElement.query(By.css('.main-image')).nativeElement;
    expect(mainImage.getAttribute('src')).toEqual(selectedJob.companyImg);
  
    const circularImage = fixture.debugElement.query(By.css('.circular-image img')).nativeElement;
    expect(circularImage.getAttribute('src')).toEqual(selectedJob.companyLogo);
  
    const designation = fixture.debugElement.query(By.css('h2')).nativeElement;
    expect(designation.textContent).toEqual(selectedJob.designation);
  
    const saveImage = fixture.debugElement.query(By.css('.save-image')).nativeElement;
    expect(saveImage.getAttribute('src')).toEqual(selectedJob.save);
  
    const companyName = fixture.debugElement.query(By.css('.companyname-location span')).nativeElement;
    expect(companyName.textContent).toContain(selectedJob.companyName);
  
    const typeOfEmployment = fixture.debugElement.queryAll(By.css('.feature-1 p:nth-child(2)'))[0].nativeElement;
    expect(typeOfEmployment.textContent).toContain(selectedJob.text1);
  
    const location = fixture.debugElement.queryAll(By.css('.feature-1 p:nth-child(2)'))[1].nativeElement;
    expect(location.textContent).toContain(selectedJob.text4);
  
    const experienceLevel = fixture.debugElement.queryAll(By.css('.feature-1 p:nth-child(2)'))[2].nativeElement;
    expect(experienceLevel.textContent).toContain(selectedJob.text2);
  
    const onsiteRemote = fixture.debugElement.queryAll(By.css('.feature-1 p:nth-child(2)'))[3].nativeElement;
    expect(onsiteRemote.textContent).toContain(selectedJob.text5);
  
    const salaryRange = fixture.debugElement.queryAll(By.css('.feature-1 p:nth-child(2)'))[4].nativeElement;
    expect(salaryRange.textContent).toContain(selectedJob.text3);
  
    const companyDescription = fixture.debugElement.query(By.css('.nav-content p')).nativeElement;
    expect(companyDescription.textContent).toEqual(selectedJob.companyContent);
  });  

  it('should handle tab switching correctly', () => {
    component.changeTab('jobDesc');
    expect(component.activeTab).toEqual('jobDesc');

    component.changeTab('responsibilities');
    expect(component.activeTab).toEqual('responsibilities');
  });
});