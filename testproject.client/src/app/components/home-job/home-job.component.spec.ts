import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HomeJobComponent } from './home-job.component';

describe('HomeJobComponent', () => {
  let component: HomeJobComponent;
  let fixture: ComponentFixture<HomeJobComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HomeJobComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HomeJobComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
