import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { UsersController } from './users.controller';

@Injectable()
export class UsersNetwork {

    usersController: UsersController;

    public constructor(http: Http, store: NgRedux<any>) {
        this.usersController = new UsersController(http, store);
    }
}
