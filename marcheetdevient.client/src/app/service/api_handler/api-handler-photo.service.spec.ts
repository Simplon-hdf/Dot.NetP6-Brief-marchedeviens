import { TestBed } from '@angular/core/testing';

import { ApiHandlerPhotoService } from './api-handler-photo.service';

describe('ApiHandlerPhotoService', () => {
  let service: ApiHandlerPhotoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiHandlerPhotoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
