import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { Investment } from '../models/investment.model';
import { InvestmentResponse } from '../models/investmentResponse.model';

@Injectable({
  providedIn: 'root'
})
export class CdbSimulatorService {

  constructor(private http: HttpClient) { }

  public async simulateCdb(cdbSimulator: Investment): Promise<InvestmentResponse> {
    return await this.http.post<any>(`${environment.apiUrl}/cdbCalculate`, cdbSimulator).toPromise();
  }
}
