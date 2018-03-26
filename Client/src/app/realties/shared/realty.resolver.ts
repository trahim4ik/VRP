import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { RealtiesNetwork } from './realties.network';
import { RealtyModel } from './realty.model';

@Injectable()
export class RealtyResolver implements Resolve<Observable<RealtyModel> | RealtyModel> {

    constructor(protected network: RealtiesNetwork) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<RealtyModel> | RealtyModel {
        const id = +route.params['id'];
        return this.network.realtyController.get(id);
    }
}
