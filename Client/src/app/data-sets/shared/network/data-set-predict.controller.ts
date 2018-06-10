import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../../core/network';
import { DataSetPredictModel } from '../models';
import { IAppState } from '../../../store/app-state';

export class DataSetPredictController extends BaseController {

    public static LOADED_DATASET_PREDICTS = 'LOADED_DATASET_PREDICTS';

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<DataSetPredictModel[]> {
        return super.httpGet(DataSetPredictController.LOADED_DATASET_PREDICTS, `DataSetPredict/${id}`, x => new DataSetPredictModel(x));
    }

}
