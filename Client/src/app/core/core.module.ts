import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminAuthGuard, AuthGuard, UnsavedChangesGuard } from './guards';
import { BaseNetwork } from './network';
import { AuthenticateXHRBackend } from './network/auth-xhr.backend';

@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [],
  providers: [
    AdminAuthGuard,
    AuthGuard,
    UnsavedChangesGuard,
    AuthenticateXHRBackend,

    BaseNetwork
  ]
})
export class CoreModule { }
