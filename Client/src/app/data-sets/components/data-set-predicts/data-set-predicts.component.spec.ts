import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetPredictsComponent } from './data-set-predicts.component';

describe('DataSetPredictsComponent', () => {
  let component: DataSetPredictsComponent;
  let fixture: ComponentFixture<DataSetPredictsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetPredictsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetPredictsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
