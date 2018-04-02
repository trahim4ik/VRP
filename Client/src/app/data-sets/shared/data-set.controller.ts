import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../core/network';
import { SearchModel, SearchResultModel } from '../../core/models';
import { DataSetModel } from './data-set.model';
import { IAppState } from '../../store/app-state';

export class DataSetController extends BaseController {

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<DataSetModel> {
        return super.httpGet(DataSetController.prototype.get, `DataSet/${id}`, x => new DataSetModel(x));
    }

    public search(model: SearchModel): Observable<SearchResultModel<DataSetModel>> {
        return super.httpPost(DataSetController.prototype.search, `DataSet/Search`, x => new SearchResultModel<DataSetModel>(x), model);
    }

    public create(model: DataSetModel): Observable<SearchResultModel<DataSetModel>> {
        return super.httpPost(DataSetController.prototype.create, `DataSet/Save`, x => new DataSetModel(x), model);
    }

    public update(model: DataSetModel): Observable<SearchResultModel<DataSetModel>> {
        return super.httpPut(DataSetController.prototype.update, `DataSet/Update`, x => new DataSetModel(x), model);
    }
}
