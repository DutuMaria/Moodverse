import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { AppPrivateService } from './app-private.service';

describe('AppPrivateService', () => {
  let service: AppPrivateService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule
      ]
    });
    service = TestBed.inject(AppPrivateService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
