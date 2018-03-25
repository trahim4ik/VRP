import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AppMaterialModule } from './../material/app-material.module';

import { AdminRoutingModule } from './admin-routing.module';
import { AdminPageComponent } from './admin-page/admin-page.component';
import { AdminSideMenuComponent } from './admin-side-menu/admin-side-menu.component';
import { AdminHomeComponent } from './admin-home/admin-home.component';

@NgModule({
  imports: [
    CommonModule,
    AppMaterialModule,
    AdminRoutingModule
  ],
  declarations: [AdminPageComponent, AdminSideMenuComponent, AdminHomeComponent]
})
export class AdminModule { }
