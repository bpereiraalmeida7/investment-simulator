import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SimulatorFormComponent } from './simulator-form/simulator-form.component';

const routes: Routes = [
  {
    path: '',
    component: SimulatorFormComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class SimulatorRoutingModule { }