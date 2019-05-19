import { Component, OnInit } from '@angular/core';
import { AuthHttpService } from 'src/app/share/services/auth-http.service';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(
    private _apiHttp: AuthHttpService
  ) { }
  model = {
    username: '',
    password: ''
  };

  ngOnInit() {
  }

  login() {
    console.log(123);
  }
}
