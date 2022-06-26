import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsuariosTabComponent } from './usuarios-tab.component';

describe('UsuariosTabComponent', () => {
  let component: UsuariosTabComponent;
  let fixture: ComponentFixture<UsuariosTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UsuariosTabComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UsuariosTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
