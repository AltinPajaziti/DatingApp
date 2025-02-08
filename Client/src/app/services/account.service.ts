import { HttpClient } from '@angular/common/http';
import { inject, Injectable, signal } from '@angular/core';
import { User } from '../Models/User';
import { map } from 'rxjs';
import { JsonPipe } from '@angular/common';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  public currentuser = signal<User | null>(null);
  private http = inject(HttpClient)
  private baseurl : string = 'https://localhost:7198/api/'

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
