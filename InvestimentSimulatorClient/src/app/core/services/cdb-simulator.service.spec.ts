import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { CdbSimulatorService } from './cdb-simulator.service';
import { Investment } from '../models/investment.model';
import { InvestmentResponse } from '../models/investmentResponse.model';
import { environment } from '../../../environments/environment';

describe('CdbSimulatorService', () => {
  let service: CdbSimulatorService;
  let httpMock: HttpTestingController;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
      providers: [CdbSimulatorService],
    });
    service = TestBed.inject(CdbSimulatorService);
    httpMock = TestBed.inject(HttpTestingController);
  });

  afterEach(() => {
    httpMock.verify();
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should simulate CDB', () => {
    const mockInvestment: Investment = {
      amount: 500,
      months: 2
    };

    const mockResponse: InvestmentResponse = {
      grossAmount: 509,
      netAmount: 507
    };

    service.simulateCdb(mockInvestment).then((response: InvestmentResponse) => {
      expect(response).toEqual(mockResponse);
    });

    const request = httpMock.expectOne(`${environment.apiUrl}/cdbCalculate`);
    expect(request.request.method).toBe('POST');
    expect(request.request.body).toEqual(mockInvestment);

    request.flush(mockResponse);
  });
});