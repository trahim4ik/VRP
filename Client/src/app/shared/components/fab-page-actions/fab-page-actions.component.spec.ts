import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FabPageActionsComponent } from './fab-page-actions.component';

describe('FabPageActionsComponent', () => {
  let component: FabPageActionsComponent;
  let fixture: ComponentFixture<FabPageActionsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FabPageActionsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FabPageActionsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
