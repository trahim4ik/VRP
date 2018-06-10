import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { MatPaginator, MatSort, MatDialog } from '@angular/material';
import { Router } from '@angular/router';

import { Observable } from 'rxjs/Observable';

import { DataSetsDataSource, DataSetsNetwork } from '../../shared';
import { PaginatorSizes, DefaultPageSize } from '../../../core/constants';
import { SearchModel } from '../../../core/models';
import { ConfirmDialogComponent } from '../../../shared/components';

@Component({
  selector: 'data-sets-page',
  templateUrl: './data-sets.component.html',
  styleUrls: ['./data-sets.component.scss']
})
export class DataSetsComponent implements OnInit {

  protected displayedColumns = ['logo', 'insertDate', 'name', 'description', 'actions'];
  protected dataSource: DataSetsDataSource;
  protected paginatorSizes = PaginatorSizes;
  protected pageSize = DefaultPageSize;
  protected searchModel = new SearchModel({ limit: DefaultPageSize });

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter') filter: ElementRef;

  constructor(
    private router: Router,
    private network: DataSetsNetwork,
    private dialog: MatDialog
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

  onDelete(id: number) {

    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: {
        title: 'Confirm dataset delete',
        content: 'Dataset related data will be removed. Are you sure you want to delete?'
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!result) {
        return;
      }

      this.network.dataSetController.delete(id)
        .subscribe((data) => { this.dataSource.reload(); });

    });
  }

  onTrain(id: number) {
    this.network.dataSetController.train(id);
  }

}
