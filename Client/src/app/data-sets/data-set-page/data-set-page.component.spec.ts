import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetPageComponent } from './data-set-page.component';

describe('DataSetPageComponent', () => {
  let component: DataSetPageComponent;
  let fixture: ComponentFixture<DataSetPageComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetPageComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
