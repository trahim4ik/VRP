import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../../core/network';
import { SearchModel, SearchResultModel } from '../../../core/models';
import { DataSetItemModel, DataSetItemSearchModel } from '../models';
import { IAppState } from '../../../store/app-state';

export class DataSetItemController extends BaseController {

    public static LOADED_DATASET_ITEM = 'LOADED_DATASET_ITEM';
    public static LOADED_DATASET_ITEMS = 'LOADED_DATASET_ITEMS';
    public static SEARCH_DATASET_ITEMS = 'LOADED_DATASET_ITEMS';
    public static LAZY_DATASET_ITEMS = 'LAZY_DATASET_ITEMS';

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<DataSetItemModel> {
        return super.httpGet(DataSetItemController.LOADED_DATASET_ITEM, `DataSetItem/${id}`, x => new DataSetItemModel(x));
    }

    public test(id: number): Observable<DataSetItemModel[]> {
        return super.httpGet(DataSetItemController.LOADED_DATASET_ITEMS, `DataSetItem/Train/${id}`, x => x);
    }

    public lazy(model: SearchModel): Observable<DataSetItemModel[]> {
        return super.httpPost(
            DataSetItemController.LAZY_DATASET_ITEMS,
            `DataSetItem/Search`,
            x => new SearchResultModel<DataSetItemModel>(x),
            model
        );
    }

    public search(model: DataSetItemSearchModel): Observable<DataSetItemModel[]> {
        return super.httpPost(
            DataSetItemController.SEARCH_DATASET_ITEMS,
            `DataSetItem/Search`,
            x => new SearchResultModel<DataSetItemModel>(x),
            model
        );
    }
}
