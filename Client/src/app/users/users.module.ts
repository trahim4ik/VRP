import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';

import { SharedModule } from '../shared/shared.module';
import { AppMaterialModule } from './../material/app-material.module';
import { UsersRoutingModule } from './users-routing.module';

import { UserComponent, UsersComponent } from './pages';
import { UsersNetwork } from './shared';

@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    AppMaterialModule,
    UsersRoutingModule,
    SharedModule
  ],
  declarations: [
    UserComponent,
    UsersComponent
  ],
  providers: [
    UsersNetwork
  ]
})
export class UsersModule { }
