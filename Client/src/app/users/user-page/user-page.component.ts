import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { select$, NgRedux } from '@angular-redux/store';
import { UserModel } from '../../core/models';
import { IAppState } from '../../store/app-state';
import { Observable } from 'rxjs/Observable';

@Component({
  selector: 'user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {

  user: UserModel;

  constructor(
    protected fb: FormBuilder,
    protected ngRedux: NgRedux<IAppState>
  ) { }

  ngOnInit() {
    this.user = this.ngRedux.getState().user;
  }

}
