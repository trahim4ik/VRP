import { Component, Input, Output, ElementRef, EventEmitter } from '@angular/core';
import { DataSetItemModel } from '../../shared';
import { DataSetItemTypeModel, DataSetItemSearchModel } from '../../shared/models';

import { Observable } from 'rxjs/Observable';

import 'rxjs/add/observable/merge';
import 'rxjs/add/observable/of';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/startWith';
import 'rxjs/add/operator/switchMap';

@Component({
  selector: 'data-set-items',
  templateUrl: './data-set-items.component.html',
  styleUrls: ['./data-set-items.component.scss']
})
export class DataSetItemsComponent {

  @Input() items: DataSetItemModel[] = [];
  @Input() searchModel: DataSetItemSearchModel;

  @Output() search = new EventEmitter();
  @Output() lazy = new EventEmitter();

  protected displayedColumns = ['district', 'productType', 'price', 'rooms', 'insertDate', 'fullArea', 'yearBuilt'];

  protected dataSetItemTypes = [
    new DataSetItemTypeModel({ value: 0, name: 'Train' }),
    new DataSetItemTypeModel({ value: 1, name: 'Test' })
  ];

  protected filter: ElementRef;

  constructor() {
  }

  onScroll() {
    console.log('scrolled!!');
  }

}
