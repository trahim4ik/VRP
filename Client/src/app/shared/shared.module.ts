import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FileDropModule } from 'ngx-file-drop';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PageHeaderComponent } from './page-header/page-header.component';
import { PageFooterComponent } from './page-footer/page-footer.component';

@NgModule({
  imports: [
    CommonModule,
    FileDropModule
  ],
  declarations: [PageNotFoundComponent, PageHeaderComponent, PageFooterComponent],
  exports: [
    FileDropModule,

    PageNotFoundComponent,
    PageHeaderComponent,
    PageFooterComponent
  ]
})
export class SharedModule { }
