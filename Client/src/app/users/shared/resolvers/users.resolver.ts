import { Injectable } from '@angular/core';
import { Resolve, ActivatedRouteSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class UsersResolver implements Resolve<any> {

    constructor() {
    }

    resolve(route: ActivatedRouteSnapshot): Observable<any> | any {
        const id = +route.params['id'];
        return id;
    }
}
