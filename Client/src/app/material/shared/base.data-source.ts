import { ElementRef } from '@angular/core';
import { DataSource } from '@angular/cdk/collections';
import { MatPaginator, MatSort, MatTableDataSource, SortDirection } from '@angular/material';

import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Observable } from 'rxjs/Observable';

import 'rxjs/add/observable/merge';
import 'rxjs/add/observable/of';
import 'rxjs/add/observable/fromEvent';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/switchMap';
import 'rxjs/add/operator/distinctUntilChanged';
import 'rxjs/add/operator/debounceTime';

import { SearchModel } from '../../core/models';

/**
 * Data source to provide what data should be rendered in the table. Note that the data source
 * can retrieve its data in any way. In this case, the data source is provided a reference
 * to a common data base. It is not the data source's responsibility to manage
 * the underlying data. Instead, it only needs to take the data and send the table exactly what
 * should be rendered.
 */
export abstract class BaseDataSource<T> extends DataSource<T> {
    total = 0;
    isLoadingResults = false;
    data: T[] = [];

    protected filterChange = new BehaviorSubject('');
    protected reloadSource = new BehaviorSubject(null);

    get filter(): string { return this.filterChange.value; }

    set filter(filter: string) { this.filterChange.next(filter); }

    constructor(
        protected paginator: MatPaginator,
        protected sort: MatSort,
        protected filterEl: ElementRef,
        protected search: SearchModel) {
        super();
        Observable.fromEvent(this.filterEl.nativeElement, 'keyup')
            .debounceTime(300)
            .distinctUntilChanged()
            .subscribe(() => {
                this.paginator.pageIndex = 0;
                this.filter = this.filterEl.nativeElement.value;
            });
        this.setSourceOptions();
    }

    protected setSourceOptions(): void {
        if (this.search.query) {
            this.filterEl.nativeElement.value = this.search.query;
            this.filter = this.filterEl.nativeElement.value;
        }

        if (this.search.direction) {
            this.sort.direction = <SortDirection>this.search.direction;
        }

        if (this.search.limit) {
            this.paginator.pageSize = this.search.limit;
        }

        if (this.search.sort) {
            this.sort.active = this.search.sort;
        }

        if (this.search.pageIndex) {
            this.paginator.pageIndex = this.search.pageIndex;
        }
    }

    protected setSearchOptions(): void {
        this.search.query = this.filter;
        this.search.limit = this.paginator.pageSize;
        this.search.direction = this.sort.direction;
        this.search.sort = this.sort.active;
        this.search.skip = this.paginator.pageIndex * this.paginator.pageSize;
        this.search.pageIndex = this.paginator.pageIndex;
    }

    connect(): Observable<T[]> {
        const displayDataChanges = [
            this.sort.sortChange,
            this.filterChange,
            this.paginator.page,
            this.reloadSource
        ];

        this.sort.sortChange.subscribe(() => {
            this.paginator.pageIndex = 0;
        });

        return Observable.merge(...displayDataChanges)
            .startWith(null)
            .switchMap(() => {
                this.isLoadingResults = true;
                this.setSearchOptions();
                return this.loadData();
            })
            .map(data => {
                this.isLoadingResults = false;
                this.total = data.total;
                return data.items;
            })
            .catch(() => {
                this.isLoadingResults = false;
                return Observable.of([]);
            });
    }

    disconnect() { }

    reload(): void {
        this.reloadSource.next(true);
    }

    abstract loadData(): Observable<any>;
}
