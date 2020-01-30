import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoginService } from '../services/login.service';
import { NgForm } from "@angular/forms";
import { User } from '../models/user';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.html'
})
export class LoginComponent  {
  
  public login: string;
  public password: string;
  public user: Observable<User>;
  constructor(private loginService: LoginService) { }

  getUserByLoginPassword(loginForm: NgForm) {    
    this.user = this.loginService.searchUserByLoginPassword(this.login, this.password);
  }
}
