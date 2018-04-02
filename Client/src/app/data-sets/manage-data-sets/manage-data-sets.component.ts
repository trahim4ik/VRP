import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator, MatSort } from '@angular/material';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetsDataSource, DataSetsNetwork } from '../shared';
import { PaginatorSizes, DefaultPageSize } from '../../core/constants';
import { SearchModel } from '../../core/models';

@Component({
  selector: 'manage-data-sets',
  templateUrl: './manage-data-sets.component.html',
  styleUrls: ['./manage-data-sets.component.scss']
})
export class ManageDataSetsComponent implements OnInit {

  protected displayedColumns = ['insertDate', 'name', 'description', 'logo', 'actions'];
  protected dataSource: DataSetsDataSource;
  protected paginatorSizes = PaginatorSizes;
  protected pageSize = DefaultPageSize;
  protected searchModel = new SearchModel({ limit: DefaultPageSize });

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;

  constructor(
    private router: Router,
    private network: DataSetsNetwork
  ) {
  }

  ngOnInit(): void {
    this.dataSource = new DataSetsDataSource(this.paginator, this.sort, this.filter, this.searchModel, this.network);
    Observable.fromEvent(this.filter.nativeElement, 'keyup')
      .debounceTime(300)
      .distinctUntilChanged()
      .subscribe(() => {
        if (!this.dataSource) {
          return;
        }
        this.dataSource.filter = this.filter.nativeElement.value;
      });
  }

  onEdit(id: number): void {
    this.router.navigate(['/admin/datasets/', id]);
  }

}
