import { ElementRef } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';

import { Observable } from 'rxjs/Observable';

import { BaseDataSource } from '../../material/shared';
import { SearchModel, SearchResultModel } from '../../core/models';
import { DataSetsNetwork, DataSetModel } from '../shared';


export class DataSetsDataSource extends BaseDataSource<DataSetModel> {

    constructor(
        protected paginator: MatPaginator,
        protected sort: MatSort,
        protected filterEl: ElementRef,
        protected search: SearchModel,
        protected network: DataSetsNetwork
    ) {
        super(
            paginator,
            sort,
            filterEl,
            search
        );
    }

    loadData(): Observable<SearchResultModel<DataSetModel>> {
        return this.network.dataSetController.search(new SearchModel({
            query: this.filter,
            limit: this.paginator.pageSize,
            direction: this.sort.direction,
            sort: this.sort.active,
            skip: this.paginator.pageIndex * this.paginator.pageSize
        }));
    }
}
