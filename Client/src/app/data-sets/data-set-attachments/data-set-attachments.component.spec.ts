import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DataSetAttachmentsComponent } from './data-set-attachments.component';

describe('DataSetAttachmentsComponent', () => {
  let component: DataSetAttachmentsComponent;
  let fixture: ComponentFixture<DataSetAttachmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DataSetAttachmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DataSetAttachmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
