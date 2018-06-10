import { Component, Input } from '@angular/core';

import * as FileSaver from 'file-saver';

import { DataSetNetworkModel } from '../../shared/models';
import { DataSetsNetwork } from '../../shared/network';

@Component({
  selector: 'data-set-network',
  templateUrl: './data-set-network.component.html',
  styleUrls: ['./data-set-network.component.scss']
})
export class DataSetNetworkComponent {

  @Input() id: number;
  @Input() items: DataSetNetworkModel[] = [];

  protected displayedColumns = ['insertDate', 'deleteDate', 'error',  'fileSize', 'actions'];

  constructor(private network: DataSetsNetwork) { }

  onDownload(id: number, name: string): void {
    this.network.dataSetFileController.download(id)
      .toPromise()
      .then(data => {
        FileSaver.saveAs(new Blob([data]), name);
      });
  }

}
