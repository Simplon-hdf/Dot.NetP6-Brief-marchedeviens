import { TestBed } from '@angular/core/testing';

import { ApiHandlerConnectionService } from './api-handler-connection.service';

describe('ApiHandlerConnectionService', () => {
  let service: ApiHandlerConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiHandlerConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
