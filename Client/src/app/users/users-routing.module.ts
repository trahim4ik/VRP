import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { UserResolver } from './shared';

import { UserComponent, UsersComponent } from './pages';

const routes: Routes = [
  { path: '', component: UsersComponent },
  { path: ':id', component: UserComponent, resolve: { users: UserResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    UserResolver
  ]
})
export class UsersRoutingModule { }
