import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from './base.controller';

export class AuthorizationController extends BaseController {

    constructor(http: Http, protected ngRedux: NgRedux<any>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<any> {
        return super.httpGet(AuthorizationController.prototype.get, `Authorization/Get/${id}`, x => x);
    }
}
