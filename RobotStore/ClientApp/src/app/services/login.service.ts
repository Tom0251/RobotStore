import { Injectable } from '@angular/core';
import { Observable } from "rxjs";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http: HttpClient) { }

  searchUserByLoginPassword(login: string, password: string) {
    let headers = new HttpHeaders();
    headers.append('content-type', 'application/json');
    headers.append('accept', 'application/json');
    headers.append('login', login);
    headers.append('password', password);
    return this.http.get<User>('https://localhost:44304/api/users', { headers: headers });
  }
}
