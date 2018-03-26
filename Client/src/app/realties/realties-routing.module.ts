import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageRealtiesComponent } from './manage-realties/manage-realties.component';
import { RealtyPageComponent } from './realty-page/realty-page.component';

import { RealtyResolver } from './shared';

const routes: Routes = [
  { path: '', component: ManageRealtiesComponent },
  { path: ':id', component: RealtyPageComponent, resolve: { relaty: RealtyResolver } }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
  providers: [
    RealtyResolver
  ]
})
export class RealtiesRoutingModule { }
