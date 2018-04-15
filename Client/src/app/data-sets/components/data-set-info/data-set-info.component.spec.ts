import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetInfoComponent } from './data-set-info.component';

describe('DataSetInfoComponent', () => {
  let component: DataSetInfoComponent;
  let fixture: ComponentFixture<DataSetInfoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetInfoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
