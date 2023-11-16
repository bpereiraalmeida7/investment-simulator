import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { NgxSliderModule } from 'ngx-slider-v2';
import { EventEmitter } from '@angular/core';
import { SimulatorFormComponent } from './simulator-form.component';
import { CdbSimulatorService } from '../../../core/services/cdb-simulator.service';
import { LoaderService } from '../../../core/services/loader-service.service';
import { InvestmentResponse } from '../../../core/models/investmentResponse.model';

describe('SimulatorFormComponent', () => {
  let component: SimulatorFormComponent;
  let fixture: ComponentFixture<SimulatorFormComponent>;
  let cdbSimulatorServiceSpy: jasmine.SpyObj<CdbSimulatorService>;
  let loaderServiceSpy: jasmine.SpyObj<LoaderService>;

  beforeEach(() => {
    const loaderSpy = jasmine.createSpyObj('LoaderService', ['show', 'hide'], { loaderState: new EventEmitter<boolean>() });
    const cdbServiceSpy = jasmine.createSpyObj('CdbSimulatorService', ['simulateCdb']);

    TestBed.configureTestingModule({
      declarations: [SimulatorFormComponent],
      imports: [ReactiveFormsModule, NgxSliderModule],
      providers: [
        { provide: CdbSimulatorService, useValue: cdbServiceSpy },
        { provide: LoaderService, useValue: loaderSpy },
      ],
    });

    TestBed.compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SimulatorFormComponent);
    component = fixture.componentInstance;
    loaderServiceSpy = TestBed.inject(LoaderService) as jasmine.SpyObj<LoaderService>;
    cdbSimulatorServiceSpy = TestBed.inject(CdbSimulatorService) as jasmine.SpyObj<CdbSimulatorService>;
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show loader and simulate CDB on requestSimulation()', () => {
    const mockResult: InvestmentResponse = {
      grossAmount: 1000,
      netAmount: 900,
    };

    cdbSimulatorServiceSpy.simulateCdb.and.returnValue(Promise.resolve(mockResult));

    component.simulatorForm.setValue({ amount: 1000, months: 12 });

    component.requestSimulation();

    expect(loaderServiceSpy.show).toHaveBeenCalled();
    expect(cdbSimulatorServiceSpy.simulateCdb).toHaveBeenCalledWith({ amount: 1000, months: 12 });
  });
});
