import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { DataSetsNetwork } from './data-sets.network';

@Injectable()
export class DataSetResolver implements Resolve<any> {

    constructor(protected network: DataSetsNetwork) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<any> | any {
        const id = +route.params['id'];
        return this.network.dataSetController.get(id);
    }
}
