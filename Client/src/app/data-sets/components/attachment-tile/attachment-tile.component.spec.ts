import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AttachmentTileComponent } from './attachment-tile.component';

describe('AttachmentTileComponent', () => {
  let component: AttachmentTileComponent;
  let fixture: ComponentFixture<AttachmentTileComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AttachmentTileComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AttachmentTileComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
