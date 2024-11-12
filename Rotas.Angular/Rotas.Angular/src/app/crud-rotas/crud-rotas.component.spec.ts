import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrudRotasComponent } from './crud-rotas.component';

describe('CrudRotasComponent', () => {
  let component: CrudRotasComponent;
  let fixture: ComponentFixture<CrudRotasComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrudRotasComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CrudRotasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
