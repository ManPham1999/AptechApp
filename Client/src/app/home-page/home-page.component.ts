import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css'],
})
export class HomePageComponent implements OnInit {
  registerMode: boolean = false;
  model: any = {};
  constructor(private accountService: AccountService) {}
  ngOnInit(): void {
  }
  onToggleRegister(value :boolean) {
    this.registerMode = value;
  }
  onRegister(model: any) {
    return this.accountService.register(model);
  }
}
