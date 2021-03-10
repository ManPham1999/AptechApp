import { AccountService } from './../_services/account.service';
import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit {
  @Input() registerMode;
  @Output() registerModeFormChild = new EventEmitter<boolean>();
  model: any = {};
  registerSuccess: boolean = false;
  onCancle() {
    this.registerModeFormChild.emit(!this.registerMode);
  }
  constructor(private accountService: AccountService) {}
  ngOnInit(): void {}
  onRegister(model: any) {
    this.accountService.register(model).subscribe((res) => {
      this.registerSuccess = res;
      if (this.registerSuccess) {
        this.onCancle();
      }
    });
    this.registerSuccess = false;
  }
}
