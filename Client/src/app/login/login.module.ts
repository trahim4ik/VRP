import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AppMaterialModule } from './../app-material.module';

import { LoginRoutingModule } from './login-routing.module';
import { LoginPageComponent } from './login-page/login-page.component';



@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,

        AppMaterialModule,
        LoginRoutingModule
    ],
    providers: [],
    declarations: [LoginPageComponent],
    exports: [LoginPageComponent]
})
export class LoginModule {
}
