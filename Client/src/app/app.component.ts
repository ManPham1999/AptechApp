import { AccountService } from './_services/account.service';
import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { IUser } from './_model/User';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent {
  title = 'Welcome to dating app';
  constructor(private http: HttpClient,private accountService : AccountService) {}
  ngOnInit(): void {
    this.setCurrentUser();
  }
  setCurrentUser(){
    const user : IUser = JSON.parse(localStorage.getItem("user"));
    this.accountService.setCurrentUser(user);
  }
  
}
