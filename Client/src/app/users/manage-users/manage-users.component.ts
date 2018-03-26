import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { Router } from '@angular/router';
import { MatPaginator, MatSort } from '@angular/material';

import { Observable } from 'rxjs/Observable';

import { UsersDataSource, UsersNetwork } from '../shared';
import { SearchModel } from '../../core/models';
import { DefaultPageSize, PaginatorSizes } from '../../core/constants';
import { FileSystemDirectoryEntry, UploadFile, FileSystemFileEntry, UploadEvent } from 'ngx-file-drop';

@Component({
  selector: 'app-manage-users',
  templateUrl: './manage-users.component.html',
  styleUrls: ['./manage-users.component.scss']
})
export class ManageUsersComponent implements OnInit {

  protected displayedColumns = ['email', 'firstName', 'lastName', 'isAdmin', 'inActive', 'actions'];
  protected dataSource: UsersDataSource;
  protected paginatorSizes = PaginatorSizes;
  protected pageSize = DefaultPageSize;
  protected searchModel = new SearchModel({ limit: DefaultPageSize });
  public files: UploadFile[] = [];

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
    this.router.navigate(['', id]);
  }

  public dropped(event: UploadEvent) {
    this.files = event.files;
    for (const droppedFile of event.files) {

      // Is it a file?
      if (droppedFile.fileEntry.isFile) {
        const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
        fileEntry.file((file: File) => {

          // Here you can access the real file
          console.log(droppedFile.relativePath, file);

          /**
          // You could upload it like this:
          const formData = new FormData()
          formData.append('logo', file, relativePath)

          // Headers
          const headers = new HttpHeaders({
            'security-token': 'mytoken'
          })

          this.http.post('https://mybackend.com/api/upload/sanitize-and-save-logo', formData, { headers: headers, responseType: 'blob' })
          .subscribe(data => {
            // Sanitized logo returned from backend
          })
          **/

        });
      } else {
        // It was a directory (empty directories are added, otherwise only files)
        const fileEntry = droppedFile.fileEntry as FileSystemDirectoryEntry;
        console.log(droppedFile.relativePath, fileEntry);
      }
    }
  }

  public fileOver(event) {
    console.log(event);
  }

  public fileLeave(event) {
    console.log(event);
  }

}
