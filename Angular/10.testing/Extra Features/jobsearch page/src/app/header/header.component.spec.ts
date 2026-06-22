import { ComponentFixture, TestBed } from '@angular/core/testing';
import { HeaderComponent } from './header.component';
import { RouterTestingModule } from '@angular/router/testing';
import { By } from '@angular/platform-browser';
import { AllJobsComponent } from '../all-jobs/all-jobs.component';
import { ChildComponent } from '../child/child.component';
import { FooterComponent } from '../footer/footer.component';
import { SidebarComponent } from '../sidebar/sidebar.component';
import { SecondFooterComponent } from '../second-footer/second-footer.component';


describe('HeaderComponent', () => {
  let component: HeaderComponent;
  let fixture: ComponentFixture<HeaderComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [
        HeaderComponent,
        AllJobsComponent,
        ChildComponent,
        FooterComponent,
        SidebarComponent,
        SecondFooterComponent
      ],
      imports: [RouterTestingModule], // Add RouterTestingModule to configure router-related tests
    });

    fixture = TestBed.createComponent(HeaderComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create the HeaderComponent', () => {
    expect(component).toBeTruthy();
  });

  it('should contain "All Jobs" and "Saved Jobs" links', () => {
    const debugElement = fixture.debugElement;
    const links = debugElement.queryAll(By.css('a'));
    const allJobsLink = links.find(link => link.nativeElement.textContent === 'All Jobs');
    const savedJobsLink = links.find(link => link.nativeElement.textContent === 'Saved Jobs');

    expect(allJobsLink).toBeTruthy();
    expect(savedJobsLink).toBeTruthy();
  });

});