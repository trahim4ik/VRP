import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { SharedModule } from '../shared/shared.module';
import { AppMaterialModule } from './../material/app-material.module';

import { DataSetsRoutingModule } from './data-sets-routing.module';

import { DataSetActions, DataSetsNetwork } from './shared';
import { DataSetComponent, DataSetsComponent } from './pages';
import {
  AttachmentTileComponent,
  AttachmentsComponent,
  BasicDetailsComponent,
  TestDataSetComponent,
  TrainDataSetComponent
} from './components';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    AppMaterialModule,
    DataSetsRoutingModule
  ],
  declarations: [
    DataSetComponent,
    DataSetsComponent,

    AttachmentTileComponent,
    AttachmentsComponent,
    BasicDetailsComponent,
    TestDataSetComponent,
    TrainDataSetComponent
  ],
  providers: [
    DataSetActions,
    DataSetsNetwork
  ]
})
export class DataSetsModule { }
