import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { UsersNetwork } from './users.network';

@Injectable()
export class UserResolver implements Resolve<any> {

    constructor(protected network: UsersNetwork) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<any> | any {
        const id = +route.params['id'];
        return this.network.usersController.get(id);
    }
}
