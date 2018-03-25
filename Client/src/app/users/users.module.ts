import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CoreModule } from '../core/core.module';

import { AppMaterialModule } from './../material/app-material.module';
import { UsersRoutingModule } from './users-routing.module';

import { ManageUsersComponent } from './manage-users/manage-users.component';
import { UserPageComponent } from './user-page/user-page.component';
import { UsersNetwork } from './shared';


@NgModule({
  imports: [
    CommonModule,
    CoreModule,
    AppMaterialModule,
    UsersRoutingModule
  ],
  declarations: [
    ManageUsersComponent,
    UserPageComponent
  ],
  providers: [
    UsersNetwork
  ]
})
export class UsersModule { }
