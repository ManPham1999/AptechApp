import { IUser } from './../_model/User';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  // muốn dùng obserable trong html thì phải dùng từ khóa public
  constructor(public accountService: AccountService, private router: Router) {}
  model: any = {};
  isNotifi: boolean;
  loginError: string;
  ngOnInit(): void {
    this.loginError = null;
    this.isNotifi = false;
  }
  onCloseNotifi() {
    setTimeout(() => {
      this.isNotifi = false;
    }, 3000);
  }

  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('');
  }
  login = () => {
    this.accountService.login(this.model).subscribe(
      (user) => {
        this.isNotifi = true;
        this.onCloseNotifi();
        this.router.navigateByUrl('/members');
      },
      (err) => {
        this.isNotifi = true;
        this.loginError = err?.error;
        this.onCloseNotifi();
      }
    );
    this.loginError = null;
  };
}
