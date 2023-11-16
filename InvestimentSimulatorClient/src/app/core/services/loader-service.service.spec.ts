import { TestBed } from '@angular/core/testing';
import { LoaderService } from './loader-service.service';

describe('LoaderService', () => {
  let service: LoaderService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [LoaderService],
    });
    service = TestBed.inject(LoaderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should emit true when show() is called', (done: DoneFn) => {
    service.loaderState.subscribe((state: boolean) => {
      expect(state).toBe(true);
      done();
    });

    service.show();
  });

  it('should emit false when hide() is called', (done: DoneFn) => {
    service.loaderState.subscribe((state: boolean) => {
      expect(state).toBe(false);
      done();
    });

    service.hide();
  });
});
