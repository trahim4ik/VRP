import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetItemModel } from '../models';
import { DataSetsNetwork } from '../network';
import { NgRedux } from '@angular-redux/store';
import { IAppState } from '../../../store/app-state';

@Injectable()
export class DataSetItemsResolver implements Resolve<DataSetItemModel[]> {

    constructor(protected network: DataSetsNetwork, protected ngRedux: NgRedux<IAppState>) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<DataSetItemModel[]> | DataSetItemModel[] {
        const dataSetItemsSearch = this.ngRedux.getState().dataSetItemsSearch;
        dataSetItemsSearch.dataSetId = +route.params['id'];
        return this.network.dataSetItemController.search(dataSetItemsSearch);
    }

}
