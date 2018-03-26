import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DataSetsRoutingModule } from './data-sets-routing.module';
import { ManageDataSetsComponent } from './manage-data-sets/manage-data-sets.component';
import { DataSetItemsComponent } from './data-set-items/data-set-items.component';

@NgModule({
  imports: [
    CommonModule,
    DataSetsRoutingModule
  ],
  declarations: [ManageDataSetsComponent, DataSetItemsComponent]
})
export class DataSetsModule { }
