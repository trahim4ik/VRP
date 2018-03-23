import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { PageHeaderComponent } from './page-header/page-header.component';
import { PageFooterComponent } from './page-footer/page-footer.component';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [PageNotFoundComponent, PageHeaderComponent, PageFooterComponent],
  exports: [PageNotFoundComponent, PageHeaderComponent, PageFooterComponent]
})
export class SharedModule { }
