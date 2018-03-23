import { Inject, Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, Router, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AdminAuthGuard implements CanActivate {

    constructor() {
    }

    /**
     * Check user can activate route
     * if unauthorized redirects to home/login
     * @param route
     * @param state
     */
    canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): boolean {
        return false;
    }
}
