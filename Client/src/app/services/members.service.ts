import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Member } from '../Models/Member';
import { AccountService } from './account.service';
import { tap } from 'rxjs';

@Injectable({
  providedIn: 'root',
  
})
export class MembersService {
  private http = inject(HttpClient)
  baseURl = environment.apiUrl
  members = signal<Member[]>([]);

  getMembers(){
    return this.http.get<Member[]>(this.baseURl+ 'Users')
  }

  getMember(username : string){
    return this.http.get<Member>(this.baseURl+ 'Users/' + username )
  }



  updateMember(member: Member) {
    return this.http.put(this.baseURl + 'Users', member).pipe(
      tap(() => {
        this.members.update(members => members.map(m => m.username === member.username 
            ? member : m))
      })
    )
  }


  
}
