import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatSort, MatPaginator } from '@angular/material';

import { Observable } from 'rxjs/Observable';

import { DefaultPageSize, PaginatorSizes } from '../../core/constants';
import { SearchModel } from '../../core/models';
import { RealtiesDataSource, RealtiesNetwork } from '../shared';

@Component({
  selector: 'app-new-manage-realties',
  templateUrl: './manage-realties.component.html',
  styleUrls: ['./manage-realties.component.scss']
})
export class ManageRealtiesComponent implements OnInit {

  protected displayedColumns = ['price', 'area', 'latitude', 'longitude', 'zipCode', 'actions'];
  protected dataSource: RealtiesDataSource;
  protected paginatorSizes = PaginatorSizes;
  protected pageSize = DefaultPageSize;
  protected searchModel = new SearchModel({ limit: DefaultPageSize });

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;

  constructor(
    private router: Router,
    private network: RealtiesNetwork
  ) {
  }

  ngOnInit(): void {
    this.dataSource = new RealtiesDataSource(this.paginator, this.sort, this.filter, this.searchModel, this.network);
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

  protected onEdit(id: number): void {
    this.router.navigate(['', id]);
  }

}
