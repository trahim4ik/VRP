import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from './base.controller';

export class AuthController extends BaseController {

    public static LOADED_ACCOUNT = 'LOADED_ACCOUNT';
    public static LOGIN_ACCOUNT = 'LOGIN_ACCOUNT';

    constructor(http: Http, protected ngRedux: NgRedux<any>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<any> {
        return super.httpGet(AuthController.LOADED_ACCOUNT, `Account/Get/${id}`, x => x);
    }

    public login(model: any): Observable<any> {
        return super.httpPost(AuthController.LOGIN_ACCOUNT, `Account/Login`, x => x, model);
    }
}
