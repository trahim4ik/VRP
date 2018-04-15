import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule } from '@angular/forms';

import { RouterModule } from '@angular/router';
import { HttpModule, XHRBackend } from '@angular/http';
import { NgReduxModule } from '@angular-redux/store';
import { LoadingBarHttpModule } from '@ngx-loading-bar/http';
import { LoadingBarRouterModule } from '@ngx-loading-bar/router';

import { AppRoutingModule } from './app-routing.module';
import { StoreModule } from './store/store.module';

import { AppComponent } from './app.component';
import { AuthenticateXHRBackend } from './core/network/auth-xhr.backend';
import { CoreModule } from './core/core.module';


@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpModule,
    NgReduxModule,
    LoadingBarHttpModule,
    LoadingBarRouterModule,
    StoreModule,
    CoreModule,
    AppRoutingModule
  ],
  providers: [
    { provide: XHRBackend, useClass: AuthenticateXHRBackend }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
