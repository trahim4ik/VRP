import { Component, OnInit, Input } from '@angular/core';
import { DataSetModel } from '../shared';

@Component({
  selector: 'basic-details',
  templateUrl: './basic-details.component.html',
  styleUrls: ['./basic-details.component.scss']
})
export class BasicDetailsComponent implements OnInit {


  @Input() model: DataSetModel;

  constructor() { }

  ngOnInit() {
  }

}
