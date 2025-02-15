import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AccountService } from '../services/account.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {

  let accountservice = inject(AccountService)
  if (accountservice.currentuser()) {
    req = req.clone({
      setHeaders: {
        'Authorization': `Bearer ${accountservice.currentuser()?.token}` // Assuming currentUser() returns an object with a token
      }
    });
  }

  return next(req);
};
