import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoveRegistrationDetailsComponent } from './remove-registration-details.component';

describe('RemoveRegistrationDetailsComponent', () => {
  let component: RemoveRegistrationDetailsComponent;
  let fixture: ComponentFixture<RemoveRegistrationDetailsComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [RemoveRegistrationDetailsComponent]
    });
    fixture = TestBed.createComponent(RemoveRegistrationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
