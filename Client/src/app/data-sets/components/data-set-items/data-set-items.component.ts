import { Component, Input, OnInit } from '@angular/core';
import { DataSetItemModel } from '../../shared';

@Component({
  selector: 'data-set-items',
  templateUrl: './data-set-items.component.html',
  styleUrls: ['./data-set-items.component.scss']
})
export class DataSetItemsComponent implements OnInit {

  @Input() items: DataSetItemModel[] = [];

  protected displayedColumns = ['district', 'productType', 'price', 'rooms', 'saleDate'];

  constructor() { }

  ngOnInit() {
  }

}
