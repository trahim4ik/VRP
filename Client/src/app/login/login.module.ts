import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

import { AppMaterialModule } from './../material/app-material.module';

import { LoginRoutingModule } from './login-routing.module';
import { LoginPageComponent } from './login-page/login-page.component';

@NgModule({
    imports: [
        CommonModule,
        FormsModule,
        LoginRoutingModule,
        AppMaterialModule
    ],
    providers: [],
    declarations: [LoginPageComponent],
    exports: [LoginPageComponent]
})
export class LoginModule {
}
