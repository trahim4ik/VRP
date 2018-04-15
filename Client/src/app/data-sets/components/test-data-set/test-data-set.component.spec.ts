import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TestDataSetComponent } from './test-data-set.component';

describe('TestDataSetComponent', () => {
  let component: TestDataSetComponent;
  let fixture: ComponentFixture<TestDataSetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [TestDataSetComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TestDataSetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
