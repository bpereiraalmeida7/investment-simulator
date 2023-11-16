import { Routes } from '@angular/router';

export const routes: Routes = [
    {
        path: '',
        loadChildren: () => import('./features/simulator/simulator.module').then(m => m.SimulatorModule)
    }
];
