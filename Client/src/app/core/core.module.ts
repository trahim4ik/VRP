import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminAuthGuard, AuthGuard, UnsavedChangesGuard } from './guards';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    AdminAuthGuard,
    AuthGuard,
    UnsavedChangesGuard,
  ]
})
export class CoreModule { }
