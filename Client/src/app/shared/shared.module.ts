import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule } from 'ng2-file-upload';

import { FabPageActionsComponent } from './fab-page-actions/fab-page-actions.component';
import { FileUploadComponent } from './file-upload/file-upload.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PageHeaderComponent } from './page-header/page-header.component';
import { PageFooterComponent } from './page-footer/page-footer.component';

@NgModule({
  imports: [
    CommonModule,
    FileUploadModule
  ],
  declarations: [
    FileUploadComponent,
    FabPageActionsComponent,
    PageNotFoundComponent,
    PageHeaderComponent,
    PageFooterComponent
  ],
  exports: [
    FileUploadModule,

    FabPageActionsComponent,
    FileUploadComponent,
    PageNotFoundComponent,
    PageHeaderComponent,
    PageFooterComponent
  ]
})
export class SharedModule { }
