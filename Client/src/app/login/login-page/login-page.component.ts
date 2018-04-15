import { Component, OnInit } from '@angular/core';

import { BaseNetwork } from '../../core/network';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  model: any = {};

  constructor(protected network: BaseNetwork) {
  }

  ngOnInit(): void {
  }

  onLogin(): void {
    this.network.authotizationController.login(this.model);
  }

}
