import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ManageRealtiesComponent } from './manage-realties.component';

describe('ManageRealtiesComponent', () => {
  let component: ManageRealtiesComponent;
  let fixture: ComponentFixture<ManageRealtiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ManageRealtiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ManageRealtiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
