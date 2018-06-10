import { Component, OnInit, Input } from '@angular/core';

import * as FileSaver from 'file-saver';

import { DataSetActions, DataSetsNetwork } from '../../shared';
import { FileEntryModel } from '../../../shared/models';

@Component({
  selector: 'train-data-set',
  templateUrl: './train-data-set.component.html',
  styleUrls: ['./train-data-set.component.scss']
})
export class TrainDataSetComponent implements OnInit {


  @Input() id: number;
  @Input() files: FileEntryModel[] = [];

  protected url: string;

  constructor(public actions: DataSetActions, private network: DataSetsNetwork) { }

  ngOnInit() {
    this.url = `api/DataSet/Train/${this.id}`;
  }

  onDownload(obj: any): void {
    this.network.dataSetFileController.downloadTrained(obj.id)
      .toPromise()
      .then(data => {
        FileSaver.saveAs(new Blob([data]), `trained-result-${obj.id}.zip`);
      });
  }

}
