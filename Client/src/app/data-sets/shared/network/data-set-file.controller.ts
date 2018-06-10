import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../../core/network';
import { IAppState } from '../../../store/app-state';

export class DataSetFileController extends BaseController {

    public static LOADED_DATASET_FILE = 'LOADED_DATASET_FILE';
    public static LOADED_DATASET_TRAINED_FILE = 'LOADED_DATASET_TRAINED_FILE';

    constructor(http: Http, protected ngRedux: NgRedux<IAppState>) {
        super(http, ngRedux);
    }

    public download(id: number): Observable<any> {
        return super.downloadFile(DataSetFileController.LOADED_DATASET_FILE, `FileEntry/${id}`);
    }

    public downloadTrained(id: number): Observable<any> {
        return super.downloadFile(DataSetFileController.LOADED_DATASET_TRAINED_FILE, `DataSet/Download/${id}`);
    }

}
