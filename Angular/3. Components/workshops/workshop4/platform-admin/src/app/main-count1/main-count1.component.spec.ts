import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MainCount1Component } from './main-count1.component';

describe('MainCount1Component', () => {
  let component: MainCount1Component;
  let fixture: ComponentFixture<MainCount1Component>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MainCount1Component ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MainCount1Component);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
