import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { AmbienceService } from './ambience.service';

describe('AmbienceService', () => {
  let service: AmbienceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule
      ]
    });
    service = TestBed.inject(AmbienceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
