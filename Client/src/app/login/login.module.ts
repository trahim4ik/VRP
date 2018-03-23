import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppMaterialModule } from './../app-material.module';

import { LoginRoutingModule } from './login-routing.module';
import { LoginPageComponent } from './login-page/login-page.component';

@NgModule({
    imports: [
        CommonModule,
        ReactiveFormsModule,
        LoginRoutingModule,
        AppMaterialModule
    ],
    providers: [],
    declarations: [LoginPageComponent],
    exports: [LoginPageComponent]
})
export class LoginModule {
}
