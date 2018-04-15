import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { FileUploader } from 'ng2-file-upload';

@Component({
  selector: 'file-upload',
  templateUrl: './file-upload.component.html',
  styleUrls: ['./file-upload.component.scss']
})
export class FileUploadComponent implements OnInit {

  @Input() url: string;
  @Output() uploaded: EventEmitter<any> = new EventEmitter<any>();

  uploader: FileUploader;
  hasBaseDropZoneOver: boolean;
  hasAnotherDropZoneOver: boolean;
  unsubscribe: Function;

  constructor() { }

  ngOnInit(): void {
    this.uploader = new FileUploader({ url: this.url });
    this.unsubscribe = this.uploader.response.subscribe(response => {
      if (response) {
        this.uploaded.emit(JSON.parse(response));
      }
    });
  }

  fileOverBase(e: any): void {
    this.hasBaseDropZoneOver = e;
  }

  fileOverAnother(e: any): void {
    this.hasAnotherDropZoneOver = e;
  }

}
