import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DataSetComponent, DataSetsComponent } from './pages';
import { DataSetResolver } from './shared';

const routes: Routes = [
  { path: '', component: DataSetsComponent },
  { path: ':id', component: DataSetComponent, resolve: { dataSet: DataSetResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    DataSetResolver
  ]
})
export class DataSetsRoutingModule { }
