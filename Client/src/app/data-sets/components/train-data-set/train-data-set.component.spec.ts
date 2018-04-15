import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TrainDataSetComponent } from './train-data-set.component';

describe('TrainDataSetComponent', () => {
  let component: TrainDataSetComponent;
  let fixture: ComponentFixture<TrainDataSetComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TrainDataSetComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TrainDataSetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
