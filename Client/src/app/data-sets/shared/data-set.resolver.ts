import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetModel } from './data-set.model';
import { DataSetsNetwork } from './data-sets.network';

@Injectable()
export class DataSetResolver implements Resolve<DataSetModel> {

    constructor(protected network: DataSetsNetwork) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<DataSetModel> | DataSetModel {
        const id = +route.params['id'];
        return this.network.dataSetController.get(id);
    }
}
