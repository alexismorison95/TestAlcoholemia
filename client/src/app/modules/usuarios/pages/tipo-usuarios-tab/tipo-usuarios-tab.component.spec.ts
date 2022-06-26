import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TipoUsuariosTabComponent } from './tipo-usuarios-tab.component';

describe('TipoUsuariosTabComponent', () => {
  let component: TipoUsuariosTabComponent;
  let fixture: ComponentFixture<TipoUsuariosTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TipoUsuariosTabComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TipoUsuariosTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
