import { Component, OnInit, OnDestroy } from '@angular/core';
import { NgRedux, select } from '@angular-redux/store';
import { IAppState } from '../../store/app-state';
import { DataSetModel } from '../shared';

@Component({
  selector: 'app-data-set-page',
  templateUrl: './data-set-page.component.html',
  styleUrls: ['./data-set-page.component.scss']
})
export class DataSetPageComponent implements OnInit, OnDestroy {

  protected model: DataSetModel;
  protected unsubscribe: Function;

  constructor(protected ngRedux: NgRedux<IAppState>) { }

  ngOnInit() {
    this.onStateChange(this.ngRedux.getState());
    this.unsubscribe = this.ngRedux.subscribe(this.onStateChange.bind(this));
  }

  protected onStateChange(state: IAppState): void {
    this.model = this.ngRedux.getState().dataSet;
  }

  ngOnDestroy(): void {
    if (this.unsubscribe) {
      this.unsubscribe();
    }
  }

}
