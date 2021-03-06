import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { AdminHomeComponent } from './admin-home/admin-home.component';
import { AdminPageComponent } from './admin-page/admin-page.component';

const adminRoutes: Routes = [
  {
    path: '',
    component: AdminPageComponent,
    canActivate: [],
    children: [
      { path: '', component: AdminHomeComponent },
      { path: 'users', loadChildren: 'app/users/users.module#UsersModule' },
      { path: 'datasets', loadChildren: 'app/data-sets/data-sets.module#DataSetsModule' }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(adminRoutes)],
  exports: [RouterModule]
})
export class AdminRoutingModule { }
