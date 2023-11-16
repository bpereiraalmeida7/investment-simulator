import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CurrencyMaskModule, CurrencyMaskConfig, CURRENCY_MASK_CONFIG } from "ng2-currency-mask";
import { NgxSliderModule } from 'ngx-slider-v2';
import { CdbSimulatorService } from '../../core/services/cdb-simulator.service';
import { SimulatorRoutingModule } from './simulator-routing.module';
import { SimulatorFormComponent } from './simulator-form/simulator-form.component';

export const CustomCurrencyMaskConfig: CurrencyMaskConfig = {
  align: "left",
  allowNegative: false,
  decimal: ",",
  precision: 2,
  prefix: "",
  suffix: "",
  thousands: "."
};

@NgModule({
  declarations: [ SimulatorFormComponent ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SimulatorRoutingModule,
    NgxSliderModule,
    HttpClientModule,
    CurrencyMaskModule,
  ],
  providers: [ 
    CdbSimulatorService,
    { provide: CURRENCY_MASK_CONFIG, useValue: CustomCurrencyMaskConfig }
  ]
})
export class SimulatorModule { }
