import { Component, OnInit, Input } from '@angular/core';

import { DataSetActions } from '../../shared';
import { FileEntryModel } from '../../../shared/models';

@Component({
  selector: 'test-data-set',
  templateUrl: './test-data-set.component.html',
  styleUrls: ['./test-data-set.component.scss']
})
export class TestDataSetComponent implements OnInit {


  @Input() id: number;
  @Input() files: FileEntryModel[] = [];

  protected url: string;

  constructor(public actions: DataSetActions) { }

  ngOnInit() {
    this.url = `api/DataSet/Train/${this.id}`;
  }

}
