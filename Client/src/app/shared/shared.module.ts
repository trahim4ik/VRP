import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule } from 'ng2-file-upload';

import { AppMaterialModule } from '../material/app-material.module';
import {
  ConfirmDialogComponent,
  FabPageActionsComponent,
  FileUploadComponent,
  PageHeaderComponent
} from './components';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    FileUploadModule
  ],
  declarations: [
    ConfirmDialogComponent,
    FileUploadComponent,
    FabPageActionsComponent,
    PageHeaderComponent
  ],
  exports: [
    FileUploadModule,
    AppMaterialModule,

    ConfirmDialogComponent,
    FabPageActionsComponent,
    FileUploadComponent,
    PageHeaderComponent
  ],
  entryComponents: [
    ConfirmDialogComponent
  ]
})
export class SharedModule { }
