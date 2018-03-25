import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { select } from '@angular-redux/store';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.scss']
})
export class UserPageComponent implements OnInit {

  @select() user;

  constructor(protected fb: FormBuilder) { }

  ngOnInit() {
    console.log(this.user);
  }

}
