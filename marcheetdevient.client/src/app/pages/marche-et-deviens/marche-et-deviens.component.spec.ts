import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarcheEtDeviensComponent } from './marche-et-deviens.component';

describe('MarcheEtDeviensComponent', () => {
  let component: MarcheEtDeviensComponent;
  let fixture: ComponentFixture<MarcheEtDeviensComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MarcheEtDeviensComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MarcheEtDeviensComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});


