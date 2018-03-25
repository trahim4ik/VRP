import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from './base.controller';

export class FileController extends BaseController {

    constructor(http: Http, protected ngRedux: NgRedux<any>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<any> {
        return super.httpGet(FileController.prototype.get, `File/Get/${id}`, x => x);
    }
}
