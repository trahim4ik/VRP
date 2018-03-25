import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminAuthGuard, AuthGuard, UnsavedChangesGuard } from './guards';
import { BaseNetwork } from './network';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    AdminAuthGuard,
    AuthGuard,
    UnsavedChangesGuard,

    BaseNetwork
  ]
})
export class CoreModule { }
