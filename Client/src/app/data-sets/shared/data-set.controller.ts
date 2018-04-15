import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../core/network';
import { SearchModel, SearchResultModel } from '../../core/models';
import { DataSetModel } from './data-set.model';
import { IAppState } from '../../store/app-state';

export class DataSetController extends BaseController {

    public static LOADED_DATASET = 'LOADED_DATASET';
    public static CREATED_DATASET = 'CREATED_DATASET';
    public static UPDATED_DATASET = 'UPDATED_DATASET';
    public static DELETED_DATASET = 'DELETED_DATASET';
    public static LOADED_DATASETS = 'LOADED_DATASETS';

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<DataSetModel> {
        return super.httpGet(DataSetController.LOADED_DATASET, `DataSet/${id}`, x => new DataSetModel(x));
    }

    public search(model: SearchModel): Observable<SearchResultModel<DataSetModel>> {
        return super.httpPost(null, `DataSet/Search`, x => new SearchResultModel<DataSetModel>(x), model);
    }

    public create(model: DataSetModel): Observable<SearchResultModel<DataSetModel>> {
        return super.httpPost(DataSetController.CREATED_DATASET, `DataSet/Create`, x => new DataSetModel(x), model);
    }

    public update(model: DataSetModel): Observable<SearchResultModel<DataSetModel>> {
        return super.httpPut(DataSetController.UPDATED_DATASET, `DataSet/Update`, x => new DataSetModel(x), model);
    }
}
