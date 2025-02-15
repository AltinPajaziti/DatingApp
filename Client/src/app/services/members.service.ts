import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Member } from '../Models/Member';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
  
})
export class MembersService {
  private http = inject(HttpClient)
  private accountservice = inject(AccountService)

  baseURl = environment.apiUrl

  getMembers(){
    return this.http.get<Member[]>(this.baseURl+ 'Users',this.getHttpOptions())
  }

  getMember(username : string){
    return this.http.get<Member>(this.baseURl+ 'Users' + username , this.getHttpOptions())
  }

  getHttpOptions() {
    return {
      headers: new HttpHeaders({
        Authorization: `Bearer ${this.accountservice.currentuser()?.token}`
      })
    };
  }
  
}
