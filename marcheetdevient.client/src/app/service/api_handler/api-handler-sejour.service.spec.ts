import { TestBed } from '@angular/core/testing';

import { ApiHandlerSejourService } from './api-handler-sejour.service';

describe('ApiHandlerSejourService', () => {
  let service: ApiHandlerSejourService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiHandlerSejourService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
