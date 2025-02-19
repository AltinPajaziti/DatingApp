import { HttpClient, HttpHeaders } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { environment } from '../../environments/environment.development';
import { Member } from '../Models/Member';
import { AccountService } from './account.service';
import { of, tap } from 'rxjs';
import { Photo } from '../Models/Photo';

@Injectable({
  providedIn: 'root',
  
})
export class MembersService {
  private http = inject(HttpClient)
  baseURl = environment.apiUrl
  members = signal<Member[]>([]);


  getMembers(){
    return this.http.get<Member[]>(this.baseURl + 'users').subscribe({
      next: members => this.members.set(members)
    }) 
   }

  getMember(username : string){
    const member = this.members().find(x=>x.username == username)
    if(member != undefined) return of(member)
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


  setMainPhoto(photo: Photo) {
    return this.http.put(this.baseURl + 'users/set-main-photo/' + photo.id, {}).pipe(
      tap(() => {
        this.members.update(members => members.map(m => {
          if (m.photos.includes(photo)) {
            m.photoUrl = photo.url
          }
          return m;
        }))
      })
    )
  }

  deletePhoto(photo: Photo) {
    return this.http.delete(this.baseURl + 'users/delete-photo/' + photo.id).pipe(
      tap(() => {
        this.members.update(members => members.map(m => {
          if (m.photos.includes(photo)) {
            m.photos = m.photos.filter(x => x.id !== photo.id)
          }
          return m
        }))
      })
    )
  }


  
}
