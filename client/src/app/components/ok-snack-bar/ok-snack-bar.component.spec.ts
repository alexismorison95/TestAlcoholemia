import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OkSnackBarComponent } from './ok-snack-bar.component';

describe('OkSnackBarComponent', () => {
  let component: OkSnackBarComponent;
  let fixture: ComponentFixture<OkSnackBarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ OkSnackBarComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(OkSnackBarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
