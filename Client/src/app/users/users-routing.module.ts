import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserResolver } from './shared';

import { ManageUsersComponent } from './manage-users/manage-users.component';
import { UserPageComponent } from './user-page/user-page.component';

const routes: Routes = [
  { path: '', component: ManageUsersComponent },
  { path: ':id', component: UserPageComponent, resolve: { users: UserResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    UserResolver
  ]
})
export class UsersRoutingModule { }
