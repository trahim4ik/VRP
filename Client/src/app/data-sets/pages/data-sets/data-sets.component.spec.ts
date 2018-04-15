import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageDataSetsComponent } from './manage-data-sets.component';

describe('ManageDataSetsComponent', () => {
  let component: ManageDataSetsComponent;
  let fixture: ComponentFixture<ManageDataSetsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageDataSetsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageDataSetsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
