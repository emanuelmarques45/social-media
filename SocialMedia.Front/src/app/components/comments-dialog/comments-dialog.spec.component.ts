import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommentsDialog } from './comments-dialog.component';

describe('CommentsDialog', () => {
  let component: CommentsDialog;
  let fixture: ComponentFixture<CommentsDialog>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CommentsDialog]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CommentsDialog);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
