import { Injectable } from '@angular/core';
import { Http, ResponseContentType } from '@angular/http';
import { NgRedux } from '@angular-redux/store';

import { Observable } from 'rxjs/Observable';

import { BaseController } from '../../core/network';
import { SearchModel, UserModel, SearchResultModel } from '../../core/models';

export class UsersController extends BaseController {

    public static LOADED_USED = 'LOADED_USED';

    constructor(http: Http, protected ngRedux: NgRedux<any>) {
        super(http, ngRedux);
    }

    public get(id: number): Observable<UserModel> {
        return super.httpGet(UsersController.LOADED_USED, `Users/${id}`, x => new UserModel(x));
    }

    public search(model: SearchModel): Observable<SearchResultModel<UserModel>> {
        return super.httpPost(null, `Users/Search`, x => new SearchResultModel<UserModel>(x), model);
    }
}
