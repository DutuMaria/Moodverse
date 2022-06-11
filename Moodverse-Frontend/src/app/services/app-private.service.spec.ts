import { TestBed } from '@angular/core/testing';

import { AppPrivateService } from './app-private.service';

describe('AppPrivateService', () => {
  let service: AppPrivateService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AppPrivateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
