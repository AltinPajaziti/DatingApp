import { HttpClient } from '@angular/common/http';
import { Component, Inject, inject, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { NavComponent } from "./nav/nav.component";
import { AccountService } from './services/account.service';
import { HomeComponent } from './home/home.component';
import { NgxSpinnerComponent } from 'ngx-spinner';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, NavComponent , HomeComponent , NgxSpinnerComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  title = 'Client';
  private accountService = inject(AccountService)

  http = inject(HttpClient)
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userstring = localStorage.getItem('user')
    if(!userstring) return
    const user = JSON.parse(userstring)
    this.accountService.currentuser.set(user)

  }


// GetAlluser(){

//   this.http.get<any>('https://localhost:7198/api/Users/GetAllUsers').subscribe(
//     (Respounse)=>{
//       console.log("this is the respounse" , Respounse)
//     }
//   )
// }
 

  
}
