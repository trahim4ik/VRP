import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetItemModel } from '../models';
import { DataSetsNetwork } from '../network';

@Injectable()
export class DataSetItemsResolver implements Resolve<DataSetItemModel[]> {

    constructor(protected network: DataSetsNetwork) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<DataSetItemModel[]> | DataSetItemModel[] {
        const id = +route.params['id'];
        return this.network.dataSetItemController.test(id);
    }
}
