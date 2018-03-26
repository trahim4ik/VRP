import { ElementRef } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';

import { Observable } from 'rxjs/Observable';

import { BaseDataSource } from '../../material/shared';
import { SearchModel, SearchResultModel } from '../../core/models';
import { RealtyModel, RealtiesNetwork } from '../shared';


export class RealtiesDataSource extends BaseDataSource<RealtyModel> {

    constructor(
        protected paginator: MatPaginator,
        protected sort: MatSort,
        protected filterEl: ElementRef,
        protected search: SearchModel,
        protected network: RealtiesNetwork
    ) {
        super(
            paginator,
            sort,
            filterEl,
            search
        );
    }

    loadData(): Observable<SearchResultModel<RealtyModel>> {
        return this.network.realtyController.search(new SearchModel({
            query: this.filter,
            limit: this.paginator.pageSize,
            direction: this.sort.direction,
            sort: this.sort.active,
            skip: this.paginator.pageIndex * this.paginator.pageSize
        }));
    }
}
