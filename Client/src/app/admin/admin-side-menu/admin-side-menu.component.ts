import { Component, OnInit } from '@angular/core';
import { NavigationModel } from '../../core/models';

@Component({
  selector: 'admin-side-menu',
  templateUrl: './admin-side-menu.component.html',
  styleUrls: ['./admin-side-menu.component.scss']
})
export class AdminSideMenuComponent implements OnInit {


  mainNavigations: NavigationModel[] = [
    new NavigationModel({ title: 'Home', link: './', icon: 'home' })
  ];

  settingsNavigations: NavigationModel[] = [
    new NavigationModel({ title: 'Profile', link: './', icon: 'account_circle' })
  ];

  manageNavigations: NavigationModel[] = [
    new NavigationModel({ title: 'Users', link: './users', icon: 'supervisor_account' }),
    new NavigationModel({ title: 'Datasets', link: './datasets', icon: 'equalizer' })
  ];

  constructor() { }

  ngOnInit() {
  }

}
