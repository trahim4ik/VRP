import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { DataSetController } from './data-set.controller';
import { DataSetItemController } from './data-set-item.controller';

@Injectable()
export class DataSetsNetwork {

    dataSetController: DataSetController;
    dataSetItemController: DataSetItemController;

    public constructor(http: Http, store: NgRedux<any>) {
        this.dataSetController = new DataSetController(http, store);
        this.dataSetItemController = new DataSetItemController(http, store);
    }
}
