import { Http } from '@angular/http';
import { Injectable } from '@angular/core';
import { NgRedux } from '@angular-redux/store';

import { RealtyController } from './realty.controller';

@Injectable()
export class RealtiesNetwork {

    realtyController: RealtyController;

    public constructor(http: Http, store: NgRedux<any>) {
        this.realtyController = new RealtyController(http, store);
    }
}
