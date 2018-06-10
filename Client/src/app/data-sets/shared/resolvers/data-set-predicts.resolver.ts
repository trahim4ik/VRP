import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetPredictModel } from '../models';
import { DataSetsNetwork } from '../network';
import { NgRedux } from '@angular-redux/store';
import { IAppState } from '../../../store/app-state';

@Injectable()
export class DataSetPredictsResolver implements Resolve<DataSetPredictModel[]> {

    constructor(protected network: DataSetsNetwork, protected ngRedux: NgRedux<IAppState>) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<DataSetPredictModel[]> | DataSetPredictModel[] {
        const id = +route.params['id'];
        return this.network.dataSetPredictController.get(id);
    }

}
