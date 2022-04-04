import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EmpregadoComponent } from './empregados.component';

describe('EmpregadoComponent', () => {
  let component: EmpregadoComponent;
  let fixture: ComponentFixture<EmpregadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EmpregadoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EmpregadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
