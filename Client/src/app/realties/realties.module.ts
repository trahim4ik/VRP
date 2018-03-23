import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RealtiesRoutingModule } from './realties-routing.module';

import { ManageRealtiesComponent } from './manage-realties/manage-realties.component';
import { RealtyPageComponent } from './realty-page/realty-page.component';

@NgModule({
  imports: [
    CommonModule,
    RealtiesRoutingModule
  ],
  declarations: [ManageRealtiesComponent, RealtyPageComponent]
})
export class RealtiesModule { }
