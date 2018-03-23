import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsersRoutingModule } from './users-routing.module';

import { ManageUsersComponent } from './manage-users/manage-users.component';
import { UserPageComponent } from './user-page/user-page.component';


@NgModule({
  imports: [
    CommonModule,
    UsersRoutingModule
  ],
  declarations: [ManageUsersComponent, UserPageComponent]
})
export class UsersModule { }
