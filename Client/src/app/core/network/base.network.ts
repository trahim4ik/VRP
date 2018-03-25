import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { AuthorizationController } from './authorization.controller';
import { FileController } from './file.controller';

@Injectable()
export class BaseNetwork {

    authotizationController: AuthorizationController;
    fileController: FileController;

    public constructor(http: Http, store: NgRedux<any>) {
        this.authotizationController = new AuthorizationController(http, store);
        this.fileController = new FileController(http, store);
    }
}
