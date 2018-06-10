import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetNetworkComponent } from './data-set-network.component';

describe('DataSetNetworkComponent', () => {
  let component: DataSetNetworkComponent;
  let fixture: ComponentFixture<DataSetNetworkComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetNetworkComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetNetworkComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
