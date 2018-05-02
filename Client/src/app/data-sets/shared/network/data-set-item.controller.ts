import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../../core/network';
import { SearchModel, SearchResultModel } from '../../../core/models';
import { DataSetItemModel } from '../models';
import { IAppState } from '../../../store/app-state';

export class DataSetItemController extends BaseController {

    public static LOADED_DATASET_ITEM = 'LOADED_DATASET_ITEM';
    public static LOADED_DATASET_ITEMS = 'LOADED_DATASET_ITEMS';

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<DataSetItemModel> {
        return super.httpGet(DataSetItemController.LOADED_DATASET_ITEM, `DataSetItem/${id}`, x => new DataSetItemModel(x));
    }

    public test(id: number): Observable<DataSetItemModel[]> {
        return super.httpGet(DataSetItemController.LOADED_DATASET_ITEMS, `DataSetItem/Train/${id}`, x => x);
    }

    public search(model: SearchModel): Observable<SearchResultModel<DataSetItemModel>> {
        return super.httpPost(null, `DataSetItem/Search`, x => new SearchResultModel<DataSetItemModel>(x), model);
    }
}
