import { Component } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Options } from 'ngx-slider-v2';
import { CdbSimulatorService } from '../../../core/services/cdb-simulator.service';
import { Investment } from '../../../core/models/investment.model';
import { InvestmentResponse } from '../../../core/models/investmentResponse.model';
import { LoaderService } from '../../../core/services/loader-service.service';

@Component({
  selector: 'app-simulator-form',
  templateUrl: './simulator-form.component.html',
  styleUrl: './simulator-form.component.css'
})
export class SimulatorFormComponent {
  public simulatorForm = this.formBuilder.group({
    amount: [ 0, Validators.required ],
    months: [ 1, Validators.required ],
  });

  public simulatorCdb: Investment = {
    amount: 0,
    months: 1
  };

  public investimento: number = 0;
  public months: number = 1;  
  public resultInvestment: InvestmentResponse = {
    grossAmount: 0,
    netAmount: 0
  };

  public options: Options = {
    floor: 0,
    ceil: 100
  };

  public isLoading: boolean = false;

  constructor(
    private formBuilder: FormBuilder,
    private cdbSimulatorService: CdbSimulatorService,
    private loaderService: LoaderService
  ) {
    this.loaderService.loaderState.subscribe((state: boolean) => {
      this.isLoading = state;
    });
  }

  requestSimulation(): void {
    if (this.simulatorForm.valid) {
      this.loaderService.show();

      this.simulatorCdb.amount = this.simulatorForm.value.amount; 
      this.simulatorCdb.months = this.simulatorForm.value.months; 
      
      this.cdbSimulatorService.simulateCdb(this.simulatorCdb).then(result => {
        setTimeout(() => {
          this.resultInvestment = result;
          this.loaderService.hide();
        }, 200);
      });
    }
  }
}
