import { Component, OnInit } from '@angular/core';

import { select$, NgRedux } from '@angular-redux/store';

import { UserModel } from '../../../core/models';
import { IAppState } from '../../../store/app-state';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'user-page',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.scss']
})
export class UserComponent implements OnInit {

  user: UserModel;

  constructor(protected ngRedux: NgRedux<IAppState>) { }

  ngOnInit() {
    this.user = this.ngRedux.getState().user;
  }

}
