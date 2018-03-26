import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../core/network';
import { SearchModel, SearchResultModel } from '../../core/models';
import { RealtyModel } from './realty.model';

export class RealtyController extends BaseController {

    constructor(http: Http, protected ngRedux: NgRedux<any>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<RealtyModel> {
        return super.httpGet(RealtyController.prototype.get, `Realty/${id}`, x => new RealtyModel(x));
    }

    public search(model: SearchModel): Observable<SearchResultModel<RealtyModel>> {
        return super.httpPost(RealtyController.prototype.get, `Realty/Search`, x => new SearchResultModel<RealtyModel>(x), model);
    }
}
