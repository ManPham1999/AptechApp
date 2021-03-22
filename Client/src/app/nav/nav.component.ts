import { IUser } from './../_model/User';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AccountService } from '../_services/account.service';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  // muốn dùng obserable trong html thì phải dùng từ khóa public
  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) { }
  model: any = {};
  loginError: string;
  username: string;
  ngOnInit(): void { }
  showSuccess(username?: string) {
    this.toastr.success(`Hello ${username}`, 'Loggin successfully!');
  }
  
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('');
  }
  login = () => {
    this.accountService.login(this.model).subscribe(
      (username) => {
        this.router.navigateByUrl('/members');
        this.showSuccess(username);
      },
      (err) => {
        console.log(err);
      }
    );
  };
}
