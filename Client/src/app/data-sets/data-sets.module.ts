import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { AppMaterialModule } from './../material/app-material.module';

import { DataSetsRoutingModule } from './data-sets-routing.module';
import { ManageDataSetsComponent } from './manage-data-sets/manage-data-sets.component';
import { DataSetItemsComponent } from './data-set-items/data-set-items.component';
import { DataSetsNetwork } from './shared';
import { DataSetPageComponent } from './data-set-page/data-set-page.component';
import { BasicDetailsComponent } from './basic-details/basic-details.component';
import { DataSetAttachmentsComponent } from './data-set-attachments/data-set-attachments.component';
import { DataSetPropertiesComponent } from './data-set-properties/data-set-properties.component';
import { DataSetInfoComponent } from './data-set-info/data-set-info.component';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    AppMaterialModule,
    DataSetsRoutingModule
  ],
  declarations: [
    DataSetItemsComponent,
    DataSetPageComponent,
    ManageDataSetsComponent,
    BasicDetailsComponent,
    DataSetAttachmentsComponent,
    DataSetPropertiesComponent,
    DataSetInfoComponent
  ],
  providers: [
    DataSetsNetwork
  ]
})
export class DataSetsModule { }
