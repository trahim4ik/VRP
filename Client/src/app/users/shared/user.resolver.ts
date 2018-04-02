import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

import { UsersNetwork } from './users.network';
import { UserModel } from '../../core/models';

@Injectable()
export class UserResolver implements Resolve<UserModel> {

    constructor(protected network: UsersNetwork) {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<UserModel> | UserModel {
        const id = +route.params['id'];
        return new UserModel({});
        //return this.network.usersController.get(id);
    }
}
