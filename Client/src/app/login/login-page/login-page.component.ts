import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.scss']
})
export class LoginPageComponent implements OnInit {

  loginForm: FormGroup;

  constructor(protected fb: FormBuilder) {
  }

  ngOnInit() {
    this.createForm();
  }

  protected createForm() {
    this.loginForm = this.fb.group({
      login: '',
      password: '',
    });
  }

}
