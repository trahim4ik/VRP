import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { DataSetController } from './data-set.controller';
import { DataSetItemController } from './data-set-item.controller';
import { DataSetNetworkController } from './data-set-network.controller';
import { DataSetPredictController } from './data-set-predict.controller';
import { DataSetFileController } from './data-set-file.controller';

@Injectable()
export class DataSetsNetwork {

    dataSetController: DataSetController;
    dataSetItemController: DataSetItemController;
    dataSetNetworkController: DataSetNetworkController;
    dataSetPredictController: DataSetPredictController;
    dataSetFileController: DataSetFileController;

    public constructor(http: Http, store: NgRedux<any>) {
        this.dataSetController = new DataSetController(http, store);
        this.dataSetItemController = new DataSetItemController(http, store);
        this.dataSetNetworkController = new DataSetNetworkController(http, store);
        this.dataSetPredictController = new DataSetPredictController(http, store);
        this.dataSetFileController = new DataSetFileController(http, store);
    }
}
