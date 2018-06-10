import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetNetworkModel } from '../models';
import { DataSetsNetwork } from '../network';
import { NgRedux } from '@angular-redux/store';
import { IAppState } from '../../../store/app-state';

@Injectable()
export class DataSetNetworksResolver implements Resolve<DataSetNetworkModel[]> {

    constructor(protected network: DataSetsNetwork, protected ngRedux: NgRedux<IAppState>) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<DataSetNetworkModel[]> | DataSetNetworkModel[] {
        const id = +route.params['id'];
        return this.network.dataSetNetworkController.get(id);
    }

}
