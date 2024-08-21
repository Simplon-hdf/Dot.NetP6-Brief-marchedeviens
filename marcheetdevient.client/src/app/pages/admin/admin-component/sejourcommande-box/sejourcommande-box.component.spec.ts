import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SejourcommandeBoxComponent } from './sejourcommande-box.component';

describe('SejourcommandeBoxComponent', () => {
  let component: SejourcommandeBoxComponent;
  let fixture: ComponentFixture<SejourcommandeBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SejourcommandeBoxComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SejourcommandeBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
