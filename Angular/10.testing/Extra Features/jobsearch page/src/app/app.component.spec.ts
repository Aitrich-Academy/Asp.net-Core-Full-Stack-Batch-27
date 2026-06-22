import { TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { AppComponent } from './app.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { AllJobsComponent } from './all-jobs/all-jobs.component';
import { ChildComponent } from './child/child.component';
import { SecondFooterComponent } from './second-footer/second-footer.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';

describe('AppComponent', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [RouterTestingModule],
    declarations: [
      AppComponent,
      SidebarComponent,
      AllJobsComponent,
      ChildComponent,
      SecondFooterComponent,
      HeaderComponent,
      FooterComponent
    ]
  }));

  it('should create the app', () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app).toBeTruthy();
  });

  it(`should have as title 'jobsearchPage'`, () => {
    const fixture = TestBed.createComponent(AppComponent);
    const app = fixture.componentInstance;
    expect(app.title).toEqual('jobsearchPage');
  });

  it('should render title', () => {
    const fixture = TestBed.createComponent(AppComponent);
    fixture.detectChanges();
    const compiled = fixture.nativeElement as HTMLElement;
    expect(compiled.querySelector('.content span')?.textContent).toContain('jobsearchPage app is running!');
  });
});
