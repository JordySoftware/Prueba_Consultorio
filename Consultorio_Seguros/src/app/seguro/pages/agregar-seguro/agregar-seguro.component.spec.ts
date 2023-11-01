import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregarSeguroComponent } from './agregar-seguro.component';

describe('AgregarSeguroComponent', () => {
  let component: AgregarSeguroComponent;
  let fixture: ComponentFixture<AgregarSeguroComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AgregarSeguroComponent]
    });
    fixture = TestBed.createComponent(AgregarSeguroComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
