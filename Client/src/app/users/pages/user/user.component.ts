import { Component, OnInit, OnDestroy } from '@angular/core';

import { select$, NgRedux } from '@angular-redux/store';

import { UserModel } from '../../../core/models';
import { IAppState } from '../../../store/app-state';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'user-page',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit, OnDestroy {

  protected user: UserModel;
  protected title: string;
  protected unsubscribe: Function;

  constructor(protected ngRedux: NgRedux<IAppState>) { }

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
    this.user = this.ngRedux.getState().user || new UserModel();
    this.title = this.user && this.user.id ? 'Edit User' : 'Create User';
  }

  protected onSave(): void {
  }

  protected onCancel(): void {
  }

}
