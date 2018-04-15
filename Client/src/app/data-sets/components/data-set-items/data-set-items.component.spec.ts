import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetItemsComponent } from './data-set-items.component';

describe('DataSetItemsComponent', () => {
  let component: DataSetItemsComponent;
  let fixture: ComponentFixture<DataSetItemsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetItemsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetItemsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
