import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgRedux, select } from '@angular-redux/store';

import { IAppState } from '../../../store/app-state';
import { DataSetModel, DataSetsNetwork, DataSetItemModel, DataSetItemSearchModel } from '../../shared';

@Component({
  selector: 'data-set-page',
  templateUrl: './data-set.component.html',
  styleUrls: ['./data-set.component.scss']
})
export class DataSetComponent implements OnInit, OnDestroy {

  protected model: DataSetModel;
  protected dataSetItems: DataSetItemModel[];
  protected dataSetItemsSearch: DataSetItemSearchModel;
  protected unsubscribe: Function;
  protected title: string;

  constructor(protected ngRedux: NgRedux<IAppState>, protected network: DataSetsNetwork) { }

  ngOnInit() {
    this.onStateChange(this.ngRedux.getState());
    this.unsubscribe = this.ngRedux.subscribe(() => this.onStateChange(this.ngRedux.getState()));
  }

  ngOnDestroy(): void {
    if (this.unsubscribe) {
      this.unsubscribe();
    }
  }

  protected onStateChange(state: IAppState): void {
    this.model = state.dataSet || new DataSetModel();
    this.dataSetItems = state.dataSetItems || [];
    this.dataSetItemsSearch = state.dataSetItemsSearch;
    this.title = this.model && this.model.id ? 'Edit Dataset' : 'Create Dataset';
  }

  protected onSave(): void {
    if (this.model.id) {
      this.network.dataSetController.update(this.model);
    } else {
      this.network.dataSetController.create(this.model);
    }

  }

  protected onCancel(): void {

  }

  protected onSearchDataSetItems(): void {
    this.network.dataSetItemController.search(this.dataSetItemsSearch);
  }

  protected onLazyDataSetItems(): void {
    this.network.dataSetItemController.lazy(this.dataSetItemsSearch);
  }

}
