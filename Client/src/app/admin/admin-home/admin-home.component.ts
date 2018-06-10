import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.scss']
})
export class AdminHomeComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit() {
  }

  protected onCreateUser(): void {
    this.router.navigate(['/admin/users/', 0]);
  }

  protected onCreateDataset(): void {
    this.router.navigate(['/admin/datasets/', 0]);
  }

}
