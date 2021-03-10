import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { IUser } from '../_model/User';
import { map } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';
@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl = 'https://localhost:5001/api';
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}
  login(model: any) {
    return this.http.post(`${this.baseUrl}/account/login`, model).pipe(
      map((res: IUser) => {
        if (res) {
          this.currentUserSource.next(res);
          localStorage.setItem('user', JSON.stringify(res));
        }
      })
    );
  }
  register(model: any) {
    return this.http.post(`${this.baseUrl}/account/register`, model).pipe(
      map((res: IUser) => {
        if (res) {
          this.currentUserSource.next(res);
          localStorage.setItem('user', JSON.stringify(res));
          return true;
        }
        return false;
      })
    );
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
  setCurrentUser(user: IUser) {
    this.currentUserSource.next(user);
  }
}
