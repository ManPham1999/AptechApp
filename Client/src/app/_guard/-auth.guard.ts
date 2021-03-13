import { IUser } from './../_model/User';
import { map } from 'rxjs/operators';
import { AccountService } from './../_services/account.service';
import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private accountService: AccountService,
    private toastr: ToastrService,
    public router: Router
  ) {}
  canActivate(): Observable<boolean> {
    return this.accountService.currentUser$.pipe(
      map((user: IUser) => {
        if (user) {
          return true;
        }
        this.toastr.error('not login yet!', 'Please login !');
        this.router.navigateByUrl("/");
      })
    );
  }
}
