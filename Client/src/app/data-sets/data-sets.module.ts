import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';

import { SharedModule } from '../shared/shared.module';
import { AppMaterialModule } from './../material/app-material.module';

import { DataSetsRoutingModule } from './data-sets-routing.module';

import { DataSetActions, DataSetsNetwork } from './shared';
import { DataSetComponent, DataSetsComponent } from './pages';
import {
  AttachmentTileComponent,
  AttachmentsComponent,
  BasicDetailsComponent,
  DataSetItemsComponent,
  TestDataSetComponent,
  TrainDataSetComponent
} from './components';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    SharedModule,
    AppMaterialModule,
    LoadingBarHttpModule,
    LoadingBarRouterModule,
    DataSetsRoutingModule
  ],
  declarations: [
    DataSetComponent,
    DataSetsComponent,

    AttachmentTileComponent,
    AttachmentsComponent,
    BasicDetailsComponent,
    DataSetItemsComponent,
    TestDataSetComponent,
    TrainDataSetComponent
  ],
  providers: [
    DataSetActions,
    DataSetsNetwork
  ]
})
export class DataSetsModule { }
