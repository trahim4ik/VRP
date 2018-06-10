import { Component, OnInit } from '@angular/core';

import { BaseNetwork } from '../../core/network';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  model: any = {};
  hide = true;

  constructor(protected network: BaseNetwork, protected router: Router) {
  }

  ngOnInit(): void {
  }

  onLogin(): void {
    this.network.authotizationController.login(this.model).subscribe(x => {
      this.router.navigate(['/admin']);
    });
  }

}
