import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ManageRealtiesComponent } from './manage-realties/manage-realties.component';

const routes: Routes = [{ path: '', component: ManageRealtiesComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RealtiesRoutingModule { }
