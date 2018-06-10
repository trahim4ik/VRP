import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { DataSetComponent, DataSetsComponent } from './pages';
import {
  DataSetResolver,
  DataSetItemsResolver,
  DataSetNetworksResolver,
  DataSetPredictsResolver
} from './shared/resolvers';

const routes: Routes = [
  { path: '', component: DataSetsComponent },
  {
    path: ':id', component: DataSetComponent, resolve: {
      dataSet: DataSetResolver,
      dataSetItems: DataSetItemsResolver,
      dataSetNetworks: DataSetNetworksResolver,
      dataSetPredicts: DataSetPredictsResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    DataSetResolver,
    DataSetItemsResolver,
    DataSetNetworksResolver,
    DataSetPredictsResolver
  ]
})
export class DataSetsRoutingModule { }
