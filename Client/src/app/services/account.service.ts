import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  private http = inject(HttpClient)
  private baseurl : string = 'https://localhost:7198/api/'

  login(model : any){
    return this.http.post(this.baseurl + 'Account/login', model)
  }
}
