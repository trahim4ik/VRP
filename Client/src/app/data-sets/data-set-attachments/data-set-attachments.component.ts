import { Component, OnInit, Input } from '@angular/core';

import { DataSetModel } from '../shared';

@Component({
  selector: 'data-set-attachments',
  templateUrl: './data-set-attachments.component.html',
  styleUrls: ['./data-set-attachments.component.scss']
})
export class DataSetAttachmentsComponent implements OnInit {

  @Input() model: DataSetModel;

  constructor() { }

  ngOnInit() {
  }

}
