import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarAseguradoComponent } from './agregar-asegurado.component';

describe('AgregarAseguradoComponent', () => {
  let component: AgregarAseguradoComponent;
  let fixture: ComponentFixture<AgregarAseguradoComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgregarAseguradoComponent]
    });
    fixture = TestBed.createComponent(AgregarAseguradoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
