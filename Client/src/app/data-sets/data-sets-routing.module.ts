import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageDataSetsComponent } from './manage-data-sets/manage-data-sets.component';
import { DataSetPageComponent } from './data-set-page/data-set-page.component';
import { DataSetResolver } from './shared';

const routes: Routes = [
  { path: '', component: ManageDataSetsComponent },
  { path: ':id', component: DataSetPageComponent, resolve: { dataSet: DataSetResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    DataSetResolver
  ]
})
export class DataSetsRoutingModule { }
