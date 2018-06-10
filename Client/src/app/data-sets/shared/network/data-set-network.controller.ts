import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../../core/network';
import { DataSetNetworkModel } from '../models';
import { IAppState } from '../../../store/app-state';

export class DataSetNetworkController extends BaseController {

    public static LOADED_DATASET_NETWORKS = 'LOADED_DATASET_NETWORKS';

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<DataSetNetworkModel[]> {
        return super.httpGet(DataSetNetworkController.LOADED_DATASET_NETWORKS, `DataSetNetwork/${id}`, x => new DataSetNetworkModel(x));
    }

}
