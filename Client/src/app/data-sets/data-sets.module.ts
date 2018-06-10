import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';
import { InfiniteScrollModule } from 'ngx-infinite-scroll';
import { ChartsModule } from 'ng2-charts/ng2-charts';

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
  DataSetNetworkComponent,
  DataSetPredictsComponent,
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
    InfiniteScrollModule,
    DataSetsRoutingModule,
    ChartsModule
  ],
  declarations: [
    DataSetComponent,
    DataSetsComponent,

    AttachmentTileComponent,
    AttachmentsComponent,
    BasicDetailsComponent,
    DataSetItemsComponent,
    TrainDataSetComponent,
    DataSetNetworkComponent,
    DataSetPredictsComponent
  ],
  providers: [
    DataSetActions,
    DataSetsNetwork
  ]
})
export class DataSetsModule { }
