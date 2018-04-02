import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetPropertiesComponent } from './data-set-properties.component';

describe('DataSetPropertiesComponent', () => {
  let component: DataSetPropertiesComponent;
  let fixture: ComponentFixture<DataSetPropertiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetPropertiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetPropertiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
