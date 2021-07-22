import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ModifyAnnouncementsComponent } from './modify-announcements.component';

describe('ModifyAnnouncementsComponent', () => {
  let component: ModifyAnnouncementsComponent;
  let fixture: ComponentFixture<ModifyAnnouncementsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ModifyAnnouncementsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ModifyAnnouncementsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
