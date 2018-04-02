import { Component, OnInit, Input } from '@angular/core';
import { DataSetModel } from '../shared';

@Component({
  selector: 'data-set-properties',
  templateUrl: './data-set-properties.component.html',
  styleUrls: ['./data-set-properties.component.scss']
})
export class DataSetPropertiesComponent implements OnInit {

  @Input() model: DataSetModel;

  constructor() { }

  ngOnInit() {
  }

}
