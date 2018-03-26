import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppMaterialModule } from './../material/app-material.module';
import { RealtiesRoutingModule } from './realties-routing.module';

import { ManageRealtiesComponent } from './manage-realties/manage-realties.component';
import { RealtyPageComponent } from './realty-page/realty-page.component';
import { RealtiesNetwork } from './shared';

@NgModule({
  imports: [
    CommonModule,
    RealtiesRoutingModule,
    AppMaterialModule
  ],
  declarations: [
    ManageRealtiesComponent,
    RealtyPageComponent
  ],
  providers: [
    RealtiesNetwork
  ]
})
export class RealtiesModule { }
