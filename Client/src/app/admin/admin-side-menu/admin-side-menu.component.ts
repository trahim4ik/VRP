import { Component, OnInit } from '@angular/core';
import { NavigationModel } from '../../core/models';

@Component({
  selector: 'admin-side-menu',
  templateUrl: './admin-side-menu.component.html',
  styleUrls: ['./admin-side-menu.component.scss']
})
export class AdminSideMenuComponent implements OnInit {

  navigations: NavigationModel[] = [
    new NavigationModel({ title: 'Home', link: './', icon: 'home' }),
    new NavigationModel({ title: 'Users', link: './users', icon: 'supervisor_account' }),
    new NavigationModel({ title: 'Realties', link: './realties', icon: 'location_city' })
  ];

  constructor() { }

  ngOnInit() {
  }

}
