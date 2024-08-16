import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PhotocommandeBoxComponent } from './photocommande-box.component';

describe('PhotocommandeBoxComponent', () => {
  let component: PhotocommandeBoxComponent;
  let fixture: ComponentFixture<PhotocommandeBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PhotocommandeBoxComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PhotocommandeBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
