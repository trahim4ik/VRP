import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { AuthController } from './auth.controller';
import { FileController } from './file.controller';

@Injectable()
export class BaseNetwork {

    authotizationController: AuthController;
    fileController: FileController;

    public constructor(http: Http, store: NgRedux<any>) {
        this.authotizationController = new AuthController(http, store);
        this.fileController = new FileController(http, store);
    }
}
