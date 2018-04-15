import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, MatSort } from '@angular/material';

import { Observable } from 'rxjs/Observable';

import { UsersDataSource, UsersNetwork } from '../../shared';
import { SearchModel } from '../../../core/models';
import { DefaultPageSize, PaginatorSizes } from '../../../core/constants';

@Component({
  selector: 'users-page',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit {

  protected displayedColumns = ['email', 'firstName', 'lastName', 'isAdmin', 'inActive', 'actions'];
  protected dataSource: UsersDataSource;
  protected paginatorSizes = PaginatorSizes;
  protected pageSize = DefaultPageSize;
  protected searchModel = new SearchModel({ limit: DefaultPageSize });

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;

  constructor(
    private router: Router,
    private network: UsersNetwork
  ) {
  }

  ngOnInit(): void {
    this.dataSource = new UsersDataSource(this.paginator, this.sort, this.filter, this.searchModel, this.network);
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
    this.router.navigate(['/admin/users/', id]);
  }

}
