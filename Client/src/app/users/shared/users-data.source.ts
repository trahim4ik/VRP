import { ElementRef } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';

import { Observable } from 'rxjs/Observable';

import { BaseDataSource } from '../../material/shared';
import { SearchModel, UserModel } from '../../core/models';
import { UsersResultModel, UsersNetwork } from '../shared';


export class UsersDataSource extends BaseDataSource<UserModel> {

    constructor(
        protected paginator: MatPaginator,
        protected sort: MatSort,
        protected filterEl: ElementRef,
        protected search: SearchModel,
        protected network: UsersNetwork
    ) {
        super(
            paginator,
            sort,
            filterEl,
            search
        );
    }

    loadData(): Observable<UsersResultModel> {
        return this.network.usersController.search(new SearchModel({
            query: this.filter,
            limit: this.paginator.pageSize,
            direction: this.sort.direction,
            sort: this.sort.active,
            skip: this.paginator.pageIndex * this.paginator.pageSize
        }));
    }
}
