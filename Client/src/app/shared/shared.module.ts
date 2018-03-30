import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileUploadModule } from 'ng2-file-upload';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PageHeaderComponent } from './page-header/page-header.component';
import { PageFooterComponent } from './page-footer/page-footer.component';
import { FileUploadComponent } from './file-upload/file-upload.component';

@NgModule({
  imports: [
    CommonModule,
    FileUploadModule
  ],
  declarations: [
    PageNotFoundComponent,
    PageHeaderComponent,
    PageFooterComponent,
    FileUploadComponent
  ],
  exports: [
    FileUploadModule,

    FileUploadComponent,
    PageNotFoundComponent,
    PageHeaderComponent,
    PageFooterComponent
  ]
})
export class SharedModule { }
