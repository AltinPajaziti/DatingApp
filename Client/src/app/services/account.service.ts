import { HttpClient } from '@angular/common/http';
import { computed, inject, Injectable, signal } from '@angular/core';
import { User } from '../Models/User';
import { map } from 'rxjs';
import { JsonPipe } from '@angular/common';
import { environment } from '../../environments/environment.development';
import { LikesService } from './likes.service';
import { PresenceService } from './presence.service';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  public currentuser = signal<User | null>(null);
  private http = inject(HttpClient)
  private likes = inject(LikesService)
  private baseurl : string = environment.apiUrl
  private presenceService = inject(PresenceService)

  roles = computed(() => {
    const user = this.currentuser();
    if (user && user.token) {
      return JSON.parse(atob(user.token.split('.')[1])).role
    }
    return null;
  })

  login(model : any){
    return this.http.post<User>(this.baseurl + 'Account/login', model).pipe(
      map(user => {
        if(user){
          localStorage.setItem('user' , JSON.stringify(user))
          this.currentuser.set(user)
        }
      })
      
    )
  }

  logout(){
    localStorage.removeItem('user')
    this.currentuser.set(null)
    this.presenceService.stopHubConnection()
  
  }

  setCurrentUser(user: User) {
    localStorage.setItem('user', JSON.stringify(user));
    this.currentuser.set(user);
    this.likes.getLikeIds()
    this.presenceService.createHubConnection(user)
  }


  register(model:any){
    return this.http.post<User>(this.baseurl + 'Account/register', model).pipe(
      map(user=>{
        if(user){
          localStorage.setItem('user', JSON.stringify(user));
          this.currentuser.set(user);
        }
        return user;
      })
    )
  }
}
