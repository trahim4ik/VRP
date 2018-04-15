import { Component, OnInit, Input } from '@angular/core';

import { DataSetActions } from '../../shared';

@Component({
  selector: 'train-data-set',
  templateUrl: './train-data-set.component.html',
  styleUrls: ['./train-data-set.component.scss']
})
export class TrainDataSetComponent implements OnInit {


  @Input() id: number;

  protected url: string;

  constructor(public actions: DataSetActions) { }

  ngOnInit() {
    this.url = `api/DataSet/Train/${this.id}`;
  }

}
